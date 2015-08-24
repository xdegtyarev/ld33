using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class CardView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler {
    Vector3 startPosition;
    Transform startParent;
    public CardStack currentStack;
    Card card;

    [SerializeField] AudioClip cardPick;
    [SerializeField] AudioClip cardDrop;
    [SerializeField] Text nameLabel;
    [SerializeField] Text descLabel;
    [SerializeField] Text viewLabel;
    [SerializeField] Image viewBacking;
    [SerializeField] Image[] colorAccents;
    [SerializeField] GameObject frontView;
    [SerializeField] GameObject selection;
    bool enemy;

    public virtual void Setup(Card cardData) {
        card = cardData;
        nameLabel.text = card.name;
        viewLabel.text = card.view;
        foreach (var o in colorAccents) {
            o.color = CardFactory.GetAccentsColorOfFraction(card.fraction);
        }
        viewBacking.color = CardFactory.GetViewBackingAccentsColorOfFraction(card.fraction);
        descLabel.text = cardData.description.Replace("NEWLINE","\n");
    }

    public void Open(bool open) {
        frontView.SetActive(open);
    }

    public void SetEnemyCard(){
        enemy = true;
    }

    public void UpdateView() {

    }

    public Card GetCardData() {
        return card;
    }

    Transform parentTransform;

    public void OnPointerClick(PointerEventData eventData) {
        switch (card.state) {
            case CardState.Stacked:
                if (card.state == CardState.Stacked) {
                    if (TurnManager.IsCardDrawn()) {
                        Tooltip.Show("Only one card can be drawn per turn");
                        break;
                    } else {
                        if (currentStack != null) {
                            currentStack.Draw();
                        }
                    }
                }
                Open(true);
                AudioSource.PlayClipAtPoint(cardPick, Vector3.zero);
                Player.instance.playerHand.PickCard(this);
                break;
            case CardState.Handed:
                if(!enemy){
                    CardPreviewer.instance.PreviewCard(this);
                }
                break;
            case CardState.Arena:
                if(enemy){
                    CardPreviewer.instance.PreviewCard(this);
                }else{
                    Tap();
                }
                break;
            case CardState.Tapped:
                CardPreviewer.instance.PreviewCard(this);
                break;
            case CardState.Dead:
                CardPreviewer.instance.PreviewCard(this);
                break;
        }
    }

    public virtual void Tap() {
        transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 30f));
        card.Use();
        card.state = CardState.Tapped;
    }

    public virtual void Untap() {
        transform.localRotation = Quaternion.identity;
        card.state = CardState.Arena;
    }

    public void OnBeginDrag(PointerEventData eventData) {
        if (card.state == CardState.Stacked) {
            if (TurnManager.IsCardDrawn()) {
                Tooltip.Show("Only one card can be drawn per turn");
                return;
            } else {
                if (currentStack != null) {
                    currentStack.Draw();
                }
            }
        }

        if (card.CanDrag()) {
            AudioSource.PlayClipAtPoint(cardPick, Vector3.zero);
            Open(true);
            parentTransform = transform.parent;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
            DragDropManager.RegisterDragTarget(gameObject);
        }

    }

    public void OnDrag(PointerEventData eventData) {
        if (card.state == CardState.Stacked && TurnManager.IsCardDrawn()) {
            return;
        }

        if (card.CanDrag()) {
            transform.localPosition = new Vector3((eventData.position.x/Screen.width)*800f-400f,(eventData.position.y/Screen.height)*600f-300f,0);
        }
    }

    public void OnEndDrag(PointerEventData eventData) {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        DragDropManager.ResetDragTarget(gameObject);
        AudioSource.PlayClipAtPoint(cardDrop, Vector3.zero);
        if (card.state == CardState.Stacked || card.state == CardState.Handed) {
            Player.instance.playerHand.PickCard(this);
        }
    }

}

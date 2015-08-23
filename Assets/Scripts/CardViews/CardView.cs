using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class CardView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler {
    Vector3 startPosition;
    Transform startParent;
    public CardStack currentStack;
    Card card;
    [SerializeField] Text nameLabel;
    [SerializeField] Text descLabel;
    [SerializeField] Text viewLabel;
    [SerializeField] Image viewBacking;
    [SerializeField] Image[] colorAccents;
    [SerializeField] GameObject frontView;
    [SerializeField] GameObject selection;

    public virtual void Setup(Card cardData) {
        card = cardData;
        nameLabel.text = card.name;
        viewLabel.text = card.view;
        foreach (var o in colorAccents) {
            o.color = CardFactory.GetAccentsColorOfFraction(card.fraction);
        }
        viewBacking.color = CardFactory.GetViewBackingAccentsColorOfFraction(card.fraction);
    }

    public void Open(bool open) {
        frontView.SetActive(open);
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
                Player.instance.playerHand.PickCard(this);
                break;
            case CardState.Handed:
                CardPreviewer.instance.PreviewCard(this);
                break;
            case CardState.Arena:
                Tap();
                break;
            case CardState.Tapped:
                Tooltip.Show("Сard can be used only once per turn");
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
            transform.localPosition = eventData.position - new Vector2(400, 300); //half screen offset
        }
    }

    public void OnEndDrag(PointerEventData eventData) {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        DragDropManager.ResetDragTarget(gameObject);
        if (card.state == CardState.Stacked || card.state == CardState.Handed) {
            Player.instance.playerHand.PickCard(this);
        }
    }

}

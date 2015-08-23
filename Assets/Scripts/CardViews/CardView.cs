using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class CardView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler {
    Vector3 startPosition;
    Transform startParent;

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

    public Card GetCardData(){
        return card;
    }

    Transform parentTransform;

    public void OnPointerClick(PointerEventData eventData) {
        switch (card.state) {
            case CardState.Stacked:
                Open(true);
                Player.instance.playerHand.PickCard(this);
                break;
            case CardState.Handed:
                CardPreviewer.instance.PreviewCard(this);
                break;
            case CardState.Arena:
                transform.localRotation = Quaternion.Euler(new Vector3(0f,0f,30f));
                card.Use();
                card.state = CardState.Tapped;
                break;
            case CardState.Tapped:
                //nothing
                break;
            case CardState.Dead:
                CardPreviewer.instance.PreviewCard(this);
                break;
        }
    }

    public void OnBeginDrag(PointerEventData eventData) {
        Open(true);
        parentTransform = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        DragDropManager.RegisterDragTarget(gameObject);
    }

    public void OnDrag(PointerEventData eventData) {
        transform.localPosition = eventData.position - new Vector2(400,300); //half screen offset
    }

    public void OnEndDrag(PointerEventData eventData) {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        DragDropManager.ResetDragTarget(gameObject);
        if(card.state == CardState.Stacked){

        }
    }

}

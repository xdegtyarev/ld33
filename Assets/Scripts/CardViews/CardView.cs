using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class CardView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
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

    Transform parentTransform;

    public void OnBeginDrag(UnityEngine.EventSystems.PointerEventData eventData) {
        parentTransform = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        DragDropManager.RegisterDragTarget(gameObject);
    }

    public void OnDrag(UnityEngine.EventSystems.PointerEventData eventData) {
        transform.localPosition = eventData.position - new Vector2(400,300); //half screen offset
    }

    public void OnEndDrag(UnityEngine.EventSystems.PointerEventData eventData) {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        DragDropManager.ResetDragTarget(gameObject);
    }

}

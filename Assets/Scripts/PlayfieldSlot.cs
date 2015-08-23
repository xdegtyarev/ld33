using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class PlayfieldSlot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {
	public CardView card;
	[SerializeField] GameObject selection;

	public void AttachCard(CardView attachment){
		card = attachment;
		card.Open(true);
    	card.GetComponent<RectTransform>().SetParent(transform);
    	card.GetComponent<RectTransform>().localPosition = Vector3.zero;
    	card.GetComponent<RectTransform>().localRotation = Quaternion.identity;
    	card.GetComponent<RectTransform>().localScale = Vector3.one;
		card.GetCardData().state = CardState.Arena;
	}

    public void OnDrop(PointerEventData eventData) {
    	if(card == null && DragDropManager.GetDraggedObject()!=null ){
    		var attachment = DragDropManager.GetDraggedObject().GetComponent<CardView>();
    		if(attachment.GetCardData().state != CardState.Arena && attachment.GetCardData().state != CardState.Tapped && attachment.GetCardData().state!=CardState.Stacked){
    			AttachCard(attachment);
	    	}
	    	selection.SetActive(false);
    	}
    }

    public void OnPointerExit(PointerEventData eventData) {
    	if(card==null){
	    	if(DragDropManager.IsDragging()){
	    		selection.SetActive(false);
	    	}
    	}
    }

    public void OnPointerEnter(PointerEventData eventData) {
    	if(card==null){
	    	if(DragDropManager.IsDragging()){
				selection.SetActive(true);
			}
		}
    }

}

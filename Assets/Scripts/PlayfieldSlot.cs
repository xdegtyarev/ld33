using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class PlayfieldSlot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {
	[SerializeField] GameObject selection;
	public CardView card{get{return transform.GetComponentInChildren<CardView>();}}

	public void AttachCard(CardView card){
		card.Open(true);
    	card.GetComponent<RectTransform>().SetParent(transform);
    	card.GetComponent<RectTransform>().localPosition = Vector3.zero;
    	card.GetComponent<RectTransform>().localRotation = Quaternion.identity;
    	card.GetComponent<RectTransform>().localScale = Vector3.one;
		card.GetCardData().state = CardState.Arena;
	}

    public void OnDrop(PointerEventData eventData) {
    	if(card == null && DragDropManager.GetDraggedObject()!=null && selection){
    		var attachment = DragDropManager.GetDraggedObject().GetComponent<CardView>();
    		if(attachment.GetCardData().state != CardState.Arena && attachment.GetCardData().state != CardState.Tapped && attachment.GetCardData().state!=CardState.Stacked){
    			AttachCard(attachment);
	    	}
	    	selection.SetActive(false);
    	}
    }

    public void OnPointerExit(PointerEventData eventData) {
    	if(card==null && selection){
	    	if(DragDropManager.IsDragging()){
	    		selection.SetActive(false);
	    	}
    	}
    }

    public void OnPointerEnter(PointerEventData eventData) {
    	if(card==null && selection){
	    	if(DragDropManager.IsDragging()){
				selection.SetActive(true);
			}
		}
    }

}

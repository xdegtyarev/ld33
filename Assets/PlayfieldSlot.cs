using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class PlayfieldSlot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {
	CardView card;
	[SerializeField] GameObject selection;

    public void OnDrop(PointerEventData eventData) {
    	if(card == null){
	    	DragDropManager.GetDraggedObject().GetComponent<RectTransform>().SetParent(transform);
	    	DragDropManager.GetDraggedObject().GetComponent<RectTransform>().localPosition = Vector3.zero;
	    	DragDropManager.GetDraggedObject().GetComponent<RectTransform>().localRotation = Quaternion.identity;
	    	DragDropManager.GetDraggedObject().GetComponent<RectTransform>().localScale = Vector3.one;
	    	card = DragDropManager.GetDraggedObject().GetComponent<CardView>();
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

using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class Hand : MonoBehaviour, IDropHandler,IPointerEnterHandler,IPointerExitHandler {

    public void OnPointerExit(PointerEventData eventData) {
    	if(DragDropManager.IsDragging()){
    		selection.SetActive(false);
    	}
    }

    public void OnPointerEnter(PointerEventData eventData) {
    	if(DragDropManager.IsDragging()){
			selection.SetActive(true);
		}
    }

	[SerializeField] Transform container;
	[SerializeField] GameObject selection;
	List<Card> cards;

    public void OnDrop(PointerEventData eventData) {
    	DragDropManager.GetDraggedObject().GetComponent<RectTransform>().SetParent(container.transform);
    	DragDropManager.GetDraggedObject().GetComponent<RectTransform>().localRotation = Quaternion.identity;
    	DragDropManager.GetDraggedObject().GetComponent<RectTransform>().localScale = Vector3.one;
    	selection.SetActive(false);
    }


}

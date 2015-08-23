using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class Hand : MonoBehaviour, IDropHandler,IPointerEnterHandler,IPointerExitHandler {
	[SerializeField] Transform container;
	[SerializeField] GameObject selection;
	List<Card> cards;


	public void PickCard(CardView card){
		card.GetComponent<RectTransform>().SetParent(container.transform);
    	card.GetComponent<RectTransform>().localRotation = Quaternion.identity;
    	card.GetComponent<RectTransform>().localScale = Vector3.one;
    	card.GetComponent<CardView>().GetCardData().state = CardState.Handed;

	}

    public void OnDrop(PointerEventData eventData) {
    	PickCard(DragDropManager.GetDraggedObject().GetComponent<CardView>());
    	selection.SetActive(false);
    }

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

}

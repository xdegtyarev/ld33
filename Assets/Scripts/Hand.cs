using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class Hand : MonoBehaviour, IDropHandler,IPointerEnterHandler,IPointerExitHandler {
	[SerializeField] bool inputEnabled;
	[SerializeField] Transform container;
	[SerializeField] GameObject selection;

    public int GetCardsCount(){
        return container.childCount;
    }

    public CardView GetRandomCard(){
        return container.GetChild(Random.Range(0, GetCardsCount())).GetComponent<CardView>();
    }

	public void PickCard(CardView card){
        if (card.GetCardData().state == CardState.Stacked && TurnManager.IsCardDrawn()) {
            return;
        }else{
    		card.GetComponent<RectTransform>().SetParent(container.transform);
        	card.GetComponent<RectTransform>().localRotation = Quaternion.identity;
        	card.GetComponent<RectTransform>().localScale = Vector3.one;
        	card.GetComponent<CardView>().GetCardData().state = CardState.Handed;
            TurnManager.SetCardDrawn();
        }
	}

    public void OnDrop(PointerEventData eventData) {
    	if(DragDropManager.IsDragging() && inputEnabled){
	    	PickCard(DragDropManager.GetDraggedObject().GetComponent<CardView>());
	    	selection.SetActive(false);
    	}
    }

    public void OnPointerExit(PointerEventData eventData) {
    	if(DragDropManager.IsDragging()&& inputEnabled){
    		selection.SetActive(false);
    	}
    }

    public void OnPointerEnter(PointerEventData eventData) {
    	if(DragDropManager.IsDragging()&& inputEnabled){
			selection.SetActive(true);
		}
    }

}

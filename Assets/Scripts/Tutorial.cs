using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Tutorial : MonoBehaviour,IPointerClickHandler {
	[SerializeField] GameObject view;

	public void Show(){
		view.SetActive(true);
	}

	public void OnPointerClick(PointerEventData eventData) {
    	view.SetActive(false);
	}
}

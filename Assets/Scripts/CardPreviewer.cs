using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CardPreviewer : MonoBehaviour,IPointerClickHandler {
	public static CardPreviewer instance;
	[SerializeField] GameObject shadow;
	CardView card;
	void Awake(){
		instance = this;
	}

    public void OnPointerClick(PointerEventData eventData) {
		card.GetComponent<RectTransform>().SetParent(prevParent);
		card.transform.localRotation = Quaternion.identity;
		card.transform.localScale = Vector3.one;
    	card = null;
    	shadow.SetActive(false);
    }

    Transform prevParent;
    public void PreviewCard(CardView view){
    	shadow.SetActive(true);
    	card = view;
    	prevParent = card.transform.parent;
    	card.GetComponent<RectTransform>().SetParent(transform);
    	card.transform.localPosition = Vector3.zero;
		card.transform.localRotation = Quaternion.identity;
		card.transform.localScale = Vector3.one;
    }

}

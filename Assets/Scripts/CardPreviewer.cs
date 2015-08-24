using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CardPreviewer : MonoBehaviour,IPointerClickHandler {
	public static CardPreviewer instance;
	[SerializeField] GameObject shadow;
    [SerializeField] AudioClip audioClip;
	CardView card;
	void Awake(){
		instance = this;
	}

    public void OnPointerClick(PointerEventData eventData) {
		card.GetComponent<RectTransform>().SetParent(prevParent);
        card.transform.localPosition = Vector3.zero;
		card.transform.localRotation = prevRot;
		card.transform.localScale = Vector3.one;
        card.GetCardData().state = prevState;
    	card = null;
    	shadow.SetActive(false);
    }

    Transform prevParent;
    CardState prevState;
    Quaternion prevRot;

    public void PreviewCard(CardView view){
    	shadow.SetActive(true);
    	card = view;
        AudioSource.PlayClipAtPoint(audioClip, Vector3.zero);
    	prevParent = card.transform.parent;
        prevState = card.GetCardData().state;
        card.GetCardData().state = CardState.Preview;
    	card.GetComponent<RectTransform>().SetParent(transform);
    	card.transform.localPosition = Vector3.zero;
        prevRot = card.transform.localRotation;
		card.transform.localRotation = Quaternion.identity;
		card.transform.localScale = Vector3.one;
    }

}

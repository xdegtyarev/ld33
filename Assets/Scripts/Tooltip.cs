using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour,IPointerClickHandler {
	[SerializeField] GameObject shadow;
	[SerializeField] Text tooltipText;
	[SerializeField] AudioClip error;
	static Tooltip instance;

	void Awake(){
		instance = this;
	}

	public static void Show(string text){
		AudioSource.PlayClipAtPoint(instance.error, Vector3.zero);
		instance.tooltipText.text = text;
		instance.shadow.SetActive(true);
	}

	public void OnPointerClick(PointerEventData eventData) {
    	shadow.SetActive(false);
	}

}

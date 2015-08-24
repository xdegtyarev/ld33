using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NotificationManager : MonoBehaviour {
	[SerializeField] Text label;
	[SerializeField] Image image;

	public static NotificationManager instance;

	void Awake(){
		instance = this;
	}

	public void ShowNotification(string text,Color color){
		label.color = new Color(label.color.r,label.color.g,label.color.b,1f);
		label.text = text;
		image.color = color;
	}

	public void Update(){
		if(label.color.a>0f){
			label.color = new Color(label.color.r,label.color.g,label.color.b,label.color.a-Time.deltaTime*0.25f);
		}

		if(image.color.a>0f){
			image.color = new Color(image.color.r,image.color.g,image.color.b,image.color.a-Time.deltaTime*0.25f);
		}
	}
}



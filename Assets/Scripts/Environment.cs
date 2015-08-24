using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Environment : MonoBehaviour {
	public static Environment instance;
	[SerializeField] Camera cam;
	[SerializeField] Image background;
	[SerializeField] Color[] fractionAccents;
	[SerializeField] Color[] fractionImageAccents;
	[SerializeField] public int currentFraction;
	[SerializeField] public float currentFractionMultiplier;
	EnvironmentCardView currentEnvCard;

	void Awake(){
		instance=this;
	}

	public void SetCurrentEnvironment(EnvironmentCardView card){
		if(currentEnvCard!=null && currentEnvCard!=card){
			Graveyard.Engrave(currentEnvCard);
		}
		currentEnvCard = card;
		currentFraction = currentEnvCard.data.fraction;
		currentFractionMultiplier = currentEnvCard.data.fractionMultiplier;
		NotificationManager.instance.ShowNotification("Environment changed, bonus: " + currentFractionMultiplier , Color.white);
		if(currentFraction>=0){
			cam.backgroundColor = fractionAccents[currentFraction];
			background.color = fractionImageAccents[currentFraction];
		}
	}
}

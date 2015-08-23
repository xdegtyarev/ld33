using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Environment : MonoBehaviour {
	public static Environment instance;
	[SerializeField] Camera cam;
	[SerializeField] Image background;
	[SerializeField] Color[] fractionAccents;
	[SerializeField] Color[] fractionImageAccents;
	[SerializeField] int currentFraction;

	void Awake(){
		instance=this;
	}

	public void SetCurrentEnvironment(int fraction){
		currentFraction = fraction;
		if(currentFraction>=0){
			cam.backgroundColor = fractionAccents[currentFraction];
			background.color = fractionImageAccents[currentFraction];
		}
	}
}

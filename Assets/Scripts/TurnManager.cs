using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TurnManager : MonoBehaviour {
	static TurnManager instance;
	[SerializeField] Text turnCounter;
	static int currentTurn;

	public static bool cardDrawn;

	void Awake(){
		instance = this;
	}

	public static bool IsCardDrawn(){
		return cardDrawn;
	}

	public static void SetCardDrawn(){
		cardDrawn = true;
	}

	public void NextTurn(){
		cardDrawn = false;
		Enemy.instance.Play();
	}

	public static void NewTurn(){
		currentTurn++;
		instance.turnCounter.text = "Turn: " + currentTurn;
		cardDrawn = false;
		Player.instance.playerPlayfield.UntapCards();
	}
}

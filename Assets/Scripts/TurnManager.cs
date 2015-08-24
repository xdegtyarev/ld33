using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TurnManager : MonoBehaviour {
	[SerializeField] AudioClip nextTurnSound;
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
		AudioSource.PlayClipAtPoint(instance.nextTurnSound, Vector3.zero);
		cardDrawn = false;
		Enemy.instance.Play();
	}

	public static void NewTurn(){
		AudioSource.PlayClipAtPoint(instance.nextTurnSound, Vector3.zero);
		currentTurn++;
		instance.turnCounter.text = "Turn: " + currentTurn;
		cardDrawn = false;
		Player.instance.playerPlayfield.UntapCards();
	}
}

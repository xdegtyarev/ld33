using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	public static Player instance;
	[SerializeField] int hp;
	[SerializeField] int mana;
	[SerializeField] Text hpLabel;
	[SerializeField] Text manaLabel;
	public Hand playerHand;
	public Playfield playerPlayfield;

	void Awake(){
		instance = this;
	}

}

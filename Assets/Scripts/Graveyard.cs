using UnityEngine;
using System.Collections;

public class Graveyard : MonoBehaviour {
	public CardStack graveyard;
	static Graveyard instance;

	void Awake(){
		instance = this;
	}

	public static void Engrave(CardView card){
		card.GetCardData().state = CardState.Dead;
		instance.graveyard.Drop(card);
	}
}

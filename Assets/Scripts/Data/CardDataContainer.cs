using UnityEngine;
using System.Collections.Generic;

public enum CardState{
	Stacked,
	Handed,
	Arena,
	Tapped,
	Dead,
	Preview
}



[System.Serializable]
public class Card {
	public string name;
	public string view;
	public string description;
	public int fraction;
	[HideInInspector] public CardState state;
	public virtual Card Clone(){
		var newCard = MemberwiseClone() as Card;
		return newCard;
	}
	public virtual void Use(){

	}

	public bool CanDrag(){
		return state==CardState.Stacked || state == CardState.Handed;
	}
}


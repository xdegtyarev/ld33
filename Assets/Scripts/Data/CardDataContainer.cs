using UnityEngine;
using System.Collections.Generic;

public enum CardState{
	Stacked,
	Handed,
	Arena,
	Tapped,
	Dead
}



[System.Serializable]
public class Card {
	public string name;
	public string view;
	public int fraction;
	[HideInInspector] public CardState state;
	public List<string> props;
	public virtual Card Clone(){
		var newCard = MemberwiseClone() as Card;
		newCard.props = new List<string>(props.ToArray());
		return newCard;
	}
	public virtual void Use(){

	}
}


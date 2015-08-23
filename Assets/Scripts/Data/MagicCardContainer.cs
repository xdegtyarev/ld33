using UnityEngine;
using System.Collections;

[System.Serializable]
public class MagicCard:Card {
	public int attack;
}

public class MagicCardContainer: DataContainer<Card>{
	[SerializeField] MagicCard card;
	public override Card GetData(){
		return card;
	}
}

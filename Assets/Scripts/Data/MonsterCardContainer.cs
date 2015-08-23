using UnityEngine;
using System.Collections;


[System.Serializable]
public class MonsterCard:Card {}

public class MonsterCardContainer: DataContainer<Card>{
	[SerializeField] MonsterCard card;
	public override Card GetData(){
		return card;
	}
}


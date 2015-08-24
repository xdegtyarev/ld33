using UnityEngine;
using System.Collections;

[System.Serializable]
public class EnvironmentCard:Card {
	public float fractionMultiplier;
}

public class EnvironmentCardContainer: DataContainer<Card>{
	[SerializeField] EnvironmentCard card;
	public override Card GetData(){
		return card;
	}
}

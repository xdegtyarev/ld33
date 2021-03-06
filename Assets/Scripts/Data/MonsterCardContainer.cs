﻿using UnityEngine;
using System.Collections;


[System.Serializable]
public class MonsterCard:Card {
	public int hp;
	public int attack;
	public int def;
	public int weaknessFraction;
	public int resistanceFraction;
}

public class MonsterCardContainer: DataContainer<Card>{
	[SerializeField] MonsterCard card;
	public override Card GetData(){
		return card;
	}
}


using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	[SerializeField] int hp;
	[SerializeField] int mana;
	[SerializeField] List<Card> hand;
	[SerializeField] List<Card> playfield;
}

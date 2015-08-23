using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {
	public static Enemy instance;
	[SerializeField] CardStack[] stacks;
	[SerializeField] int hp;
	[SerializeField] int mana;
	[SerializeField] Text hpLabel;
	[SerializeField] Text manaLabel;
	public Hand playerHand;
	public Playfield playerPlayfield;

	void Awake(){
		instance = this;
	}

	public void Play(){
		StartCoroutine(Turn());
	}

	IEnumerator Turn(){
		playerPlayfield.UntapCards();
		yield return new WaitForSeconds(1f);
		PickRandomCard();
		yield return new WaitForSeconds(1f);
		TryPlayCards();
		yield return new WaitForSeconds(1f);
		TryTapCards();
		yield return new WaitForSeconds(1f);
		TurnManager.NewTurn();
	}

	public void PickRandomCard(){
		playerHand.PickCard(stacks[Random.Range(0, stacks.Length)].Draw());
	}

	public void TryPlayCards(){
		if(playerHand.GetCardsCount()>0 && playerPlayfield.GetEmptySlotsCount()>0){
			int randCount = Mathf.Min(Random.Range(1, playerHand.GetCardsCount()),Random.Range(1, playerPlayfield.GetEmptySlotsCount()));
			for(int i=0;i<randCount;i++){
				playerPlayfield.GetRandomFreeSlot().AttachCard(playerHand.GetRandomCard());
			}
		}
	}

	public void TryTapCards(){
		if(playerPlayfield.GetSlotsCount()>0){
			int randCount = Random.Range(1,playerPlayfield.GetSlotsCount());
			for(int i=0;i<randCount;i++){
				playerPlayfield.GetRandomSlot().card.Tap();
			}
		}
	}

}

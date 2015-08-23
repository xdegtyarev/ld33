using UnityEngine;
using System.Collections.Generic;

public class CardStack : MonoBehaviour {
	const string settingsPath = "Cards/";
	[SerializeField] string specialSettingsPath;
	[SerializeField] bool open;
	[SerializeField] int stackHeight;
	List<Card> cardsBase;
	List<CardView> cards;

	void Awake(){
		cardsBase = new List<Card>();
		foreach(var o in Resources.LoadAll<DataContainer<Card>>(settingsPath+specialSettingsPath)){
			cardsBase.Add(o.GetData());
		}
		cards = new List<CardView>();
		Generate();
	}

	public void Generate(){
		for(int i = 0; i<stackHeight && cardsBase.Count>0; i++){
			Drop(CardFactory.CreateCard(cardsBase[Random.Range(0, cardsBase.Count)].Clone()));
		}
	}

	public CardView Draw(){
		CardView draw = null;
		if(cards.Count>0){
			draw = cards[cards.Count-1];
			cards.RemoveAt(cards.Count-1);
		}
		return draw;
	}

	public void Drop(CardView card){
		cards.Add(card);
		card.currentStack = this;
		card.Open(open);
		card.transform.SetParent(transform);
		card.transform.localPosition = new Vector3(cards.Count*2,cards.Count*2,cards.Count);
		card.transform.localRotation = Quaternion.identity;
		card.transform.localScale = Vector3.one;
	}
}

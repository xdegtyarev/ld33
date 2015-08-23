using UnityEngine;
using System.Collections;

public class CardFactory : MonoBehaviour {
	[SerializeField] GameObject magicCardPrefab;
	[SerializeField] GameObject monsterCardPrefab;
	[SerializeField] GameObject environmentCardPrefab;
	[SerializeField] Color[] fractionAccents;
	[SerializeField] Color[] fractionImageAccents;
	static CardFactory instance;

	void Awake(){
		instance = this;
	}

	public static CardView CreateCard(Card cardData){
		CardView cardView = null;
		if(cardData is MagicCard){
			 cardView = Instantiate(instance.magicCardPrefab).GetComponent<MagicCardView>();
		}else if(cardData is MonsterCard){
			cardView =  Instantiate(instance.monsterCardPrefab).GetComponent<MonsterCardView>();
		}else if(cardData is EnvironmentCard){
			cardView =  Instantiate(instance.environmentCardPrefab).GetComponent<EnvironmentCardView>();
		}
		cardView.Setup(cardData);
		return cardView;
	}

	public static Color GetAccentsColorOfFraction(int fraction){
		return instance.fractionAccents[fraction];
	}

	public static Color GetViewBackingAccentsColorOfFraction(int fraction){
		return instance.fractionImageAccents[fraction];
	}

}

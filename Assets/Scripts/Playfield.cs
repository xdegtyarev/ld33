using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class Playfield : MonoBehaviour{
	[SerializeField]List<PlayfieldSlot> cardSlots;

	public int GetEmptySlotsCount(){
		int count = 0;
		foreach(var o in cardSlots){
			if(o.card==null){
				count++;
			}
		}
		return count;
	}

	public int GetSlotsCount(){
		int count = 0;
		foreach(var o in cardSlots){
			if(o.card!=null){
				count++;
			}
		}
		return count;
	}

	public void UntapCards(){
		foreach(var o in cardSlots){
			if(o.card){
				o.card.Untap();
			}
		}
	}

	public PlayfieldSlot GetRandomFreeSlot(){
		var freeslots = new List<PlayfieldSlot>();
		foreach(var o in cardSlots){
			if(!o.card){
				freeslots.Add(o);
			}
		}
		return freeslots.Count > 0 ? freeslots[Random.Range(0, freeslots.Count)] : null;
	}

	public PlayfieldSlot GetRandomSlot(){
		var slots = new List<PlayfieldSlot>();
		foreach(var o in cardSlots){
			if(o.card && o.card.GetCardData().state!=CardState.Tapped){
				slots.Add(o);
			}
		}
		return slots.Count > 0 ? slots[Random.Range(0, slots.Count)] : null;
	}
}

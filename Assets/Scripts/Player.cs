
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Player : MonoBehaviour, IHitReceiver {
	[SerializeField] int hp;
	[SerializeField] Text hpLabel;
	public Hand playerHand;
	public Playfield playerPlayfield;
	public static Player instance;
    public void ReceiveHit(int hit) {
    	hp-=hit;
    	if(hp<0){
    		Debug.Log("LOOOOSEEE");
    	}
    }

	void Awake(){
		instance = this;
	}

   void Update(){
    	hpLabel.text = "Health " + hp;
    }
}

public interface IHitReceiver {
	void ReceiveHit(int hit);
}

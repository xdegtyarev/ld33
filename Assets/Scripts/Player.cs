
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
    	NotificationManager.instance.ShowNotification("Player hit " + hit, Color.red);
    	if(hp<0){
    		GameOverScreen.EndGame(true);
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

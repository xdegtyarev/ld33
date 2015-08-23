using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MonsterCardView : CardView, IHitReceiver {
    public MonsterCard data{get{return (GetCardData() as MonsterCard);}}
    public void ReceiveHit(int hit) {
    	if(data.state == CardState.Arena){
    		hit -= (Environment.instance.currentFraction == data.fraction)?data.def*2:data.def;
    		//TODO:maybe shot back with def points left
    	}
    	if(hit>0){
    		data.hp -= hit;
    		if(data.hp<0){
    			Graveyard.Engrave(this);
    		}
    	}
    }

    void Update(){
    	hpLabel.text = "HP:" + data.hp;
    }

    public override void Tap() {
    	Debug.Log("Monster Attacks");
		base.Tap();
		TargetManager.GetTarget(this).ReceiveHit((Environment.instance.currentFraction == data.fraction)?data.attack*2:data.attack);
    }

	[SerializeField] Text hpLabel;
	[SerializeField] Image weaknessBacking;
	[SerializeField] Image resistBacking;
}

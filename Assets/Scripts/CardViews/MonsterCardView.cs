using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MonsterCardView : CardView, IHitReceiver {
    [SerializeField] AudioClip[] monsterUseClip;
    public MonsterCard data{get{return (GetCardData() as MonsterCard);}}
    public void ReceiveHit(int hit) {
    	if(data.state == CardState.Arena){
            float multiplier = 1f;
            if(Environment.instance.currentFraction == data.resistanceFraction){
                multiplier*=Environment.instance.currentFractionMultiplier;
            }
    		hit -= (int)(data.def * multiplier);
    	}
        NotificationManager.instance.ShowNotification("Monster hit " + hit, Color.white);
 		if(data.hp<0){
			Graveyard.Engrave(this);
		}
    }

    void Update(){
        weaknessBacking.color = CardFactory.GetAccentsColorOfFraction(data.weaknessFraction);
        resistBacking.color = CardFactory.GetAccentsColorOfFraction(data.resistanceFraction);
    	hpLabel.text = "HP:" + data.hp;
    }

    public override void Tap() {
    	Debug.Log("Monster Attacks");
		base.Tap();
        AudioSource.PlayClipAtPoint(monsterUseClip[Random.Range(0, monsterUseClip.Length)], Vector3.zero);

        float multiplier = 1f;
        if(Environment.instance.currentFraction == data.weaknessFraction){
            multiplier/=Environment.instance.currentFractionMultiplier;
        }
        if(Environment.instance.currentFraction == data.fraction){
            multiplier*=Environment.instance.currentFractionMultiplier;
        }
		TargetManager.GetTarget(this).ReceiveHit((int)(data.attack*multiplier));
    }

	[SerializeField] Text hpLabel;
	[SerializeField] Image weaknessBacking;
	[SerializeField] Image resistBacking;
}

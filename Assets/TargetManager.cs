using UnityEngine;
using System.Collections;

public class TargetManager : MonoBehaviour {
	public static IHitReceiver GetTarget(CardView view){
		if(Player.instance.playerPlayfield.GetCardViewRow(view) != -1){
			var playerTarget = Enemy.instance.playerPlayfield.GetCardView(Player.instance.playerPlayfield.GetCardViewRow(view));
			if(playerTarget!=null && playerTarget.GetComponent<IHitReceiver>()!=null){
				return playerTarget.GetComponent<IHitReceiver>();
			}else{
				return Enemy.instance;
			}
		}else{
			var enemyTarget = Player.instance.playerPlayfield.GetCardView(Enemy.instance.playerPlayfield.GetCardViewRow(view));
			if(enemyTarget!=null && enemyTarget.GetComponent<IHitReceiver>()!=null){
				return enemyTarget.GetComponent<IHitReceiver>();
			}else{
				return Player.instance;
			}
		}
	}
}

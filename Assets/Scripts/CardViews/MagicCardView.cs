using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MagicCardView : CardView {
	public override void Tap() {
		Debug.Log("Magic Attacks");
		base.Tap();
		var data = GetCardData() as MagicCard;
		TargetManager.GetTarget(this).ReceiveHit((Environment.instance.currentFraction == data.fraction)?(int)(data.attack*Environment.instance.currentFractionMultiplier):data.attack);
		Graveyard.Engrave(this);
    }
}

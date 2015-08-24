using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MagicCardView : CardView {
	[SerializeField] AudioClip[] magicUseClip;
	public override void Tap() {
		Debug.Log("Magic Attacks");
		base.Tap();
		AudioSource.PlayClipAtPoint(magicUseClip[Random.Range(0, magicUseClip.Length)], Vector3.zero);
		var data = GetCardData() as MagicCard;
		float multiplier = 1f;
        if(Environment.instance.currentFraction == data.fraction){
            multiplier*=Environment.instance.currentFractionMultiplier;
        }
		TargetManager.GetTarget(this).ReceiveHit((int)(data.attack*multiplier));
		StartCoroutine(Die());
    }

    public IEnumerator Die(){
    	yield return new WaitForSeconds(1f);
    	Graveyard.Engrave(this);
    }

	public override void Untap() {
    	;
    }
}

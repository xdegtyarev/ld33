using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnvironmentCardView : CardView {
	[SerializeField] AudioClip[] environmentUseClip;
	public EnvironmentCard data{get{return GetCardData() as EnvironmentCard;}}
	public override void Tap() {
		base.Tap();
        Environment.instance.SetCurrentEnvironment(this);
          AudioSource.PlayClipAtPoint(environmentUseClip[Random.Range(0, environmentUseClip.Length)], Vector3.zero);
    }


	public override void Untap() {
    	;
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnvironmentCardView : CardView {
	public EnvironmentCard data{get{return GetCardData() as EnvironmentCard;}}
	public override void Tap() {
		base.Tap();
        Environment.instance.SetCurrentEnvironment(this);
    }
}

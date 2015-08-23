using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnvironmentCardView : CardView {
	public override void Tap() {
		base.Tap();
        Environment.instance.SetCurrentEnvironment(GetCardData().fraction);
    }
}

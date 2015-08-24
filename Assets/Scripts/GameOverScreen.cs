using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverScreen : MonoBehaviour {
	public static GameOverScreen instance;
	[SerializeField]GameObject view;
	[SerializeField] Text text;
	void Awake(){
		instance = this;
	}

	public static void EndGame(bool fail){
		instance.view.SetActive(true);
		instance.text.text = fail?"Fail!":"Nice!";
	}

	public void Restart(){
		Application.LoadLevel(0);
	}
}

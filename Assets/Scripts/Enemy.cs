using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour,IHitReceiver {
    public static Enemy instance;
    [SerializeField] CardStack[] stacks;
    [SerializeField] int hp;
    [SerializeField] Text hpLabel;
    public Hand playerHand;
    public Playfield playerPlayfield;

    void Awake() {
        instance = this;
    }

    void Update(){
    	hpLabel.text = "Health " + hp;
    }

    public void Play() {
        StartCoroutine(Turn());
    }

    public void ReceiveHit(int hit) {
        hp -= hit;
        if (hp < 0) {
            Debug.Log("LOOOOSEEE");
        }
    }

    IEnumerator Turn() {
        playerPlayfield.UntapCards();
        yield return new WaitForSeconds(0.5f);
        playerHand.PickCard(stacks[Random.Range(0, stacks.Length)].Draw());
        yield return new WaitForSeconds(0.5f);
        //PlayCards
        if (playerHand.GetCardsCount() > 0 && playerPlayfield.GetEmptySlotsCount() > 0) {
            int randCount = Mathf.Min(Random.Range(1, playerHand.GetCardsCount()), Random.Range(1, playerPlayfield.GetEmptySlotsCount()));
            for (int i = 0; i < randCount; i++) {
                playerPlayfield.GetRandomFreeSlot().AttachCard(playerHand.GetRandomCard());
                yield return new WaitForSeconds(0.5f);
            }
        }
        //TapCards
        if (playerPlayfield.GetSlotsCount() > 0) {
            int randCount = Random.Range(1, playerPlayfield.GetSlotsCount());
            for (int i = 0; i < randCount; i++) {
                playerPlayfield.GetRandomSlot().card.Tap();
                yield return new WaitForSeconds(0.5f);
            }
        }

        TurnManager.NewTurn();
    }
}

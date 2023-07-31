using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    [SerializeField] private int goldScore;

    [SerializeField] public int goldEarned;
    [SerializeField] public int goldScorePub => goldScore;

    private void Start() {
        goldScore += 50;
        goldEarned += 50;
    }

    public void GiveGold(int earnedGold){
        goldScore += earnedGold;
        goldEarned += earnedGold;
    } 
    
    public void towerPrice(int cost){
        goldScore -= cost;
    }

    private void Update() {
        GetComponent<GoldView>().currentGold = goldScore;
    }
}

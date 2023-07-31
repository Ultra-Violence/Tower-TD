using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldView : MonoBehaviour
{
    public Text goldView;
    public int currentGold;

    private void Awake() {
        currentGold = 50;
    }
    
    private void Update() {
        goldView.text = ":" + currentGold.ToString();
    }
}

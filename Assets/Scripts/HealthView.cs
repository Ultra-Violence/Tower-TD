using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    public Text healthView;
    public int currentHealth;

    private void Awake() {
        currentHealth = 50;
    }
    
    private void Update() {
        healthView.text = ":" + currentHealth.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class costColor : MonoBehaviour
{   
    private GameObject GoldManager;

    private void Start() {
        GoldManager = GameObject.Find("/GoldManager");
    }
    
    void Update()
    {
        if(int.Parse(gameObject.GetComponent<Text>().text) > GoldManager.GetComponent<Gold>().goldScorePub){
            gameObject.GetComponent<Text>().color = Color.red;
        }
        else if(int.Parse(gameObject.GetComponent<Text>().text) <= GoldManager.GetComponent<Gold>().goldScorePub){
            gameObject.GetComponent<Text>().color = Color.black;
        }
    }
}

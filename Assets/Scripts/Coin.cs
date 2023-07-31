using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{   
    private float speed = 6f;

    private void Start() {
        Invoke("DestroyCoin", 2f);
    }

    private void FixedUpdate() {
        transform.Translate(Vector3.up * Time.fixedDeltaTime * speed);
    }   
    
    public void DestroyCoin(){
        GameObject GoldManager = GameObject.Find("/GoldManager");
        GoldManager.GetComponent<Gold>().GiveGold(1);
        Destroy(gameObject);
    }
    
}

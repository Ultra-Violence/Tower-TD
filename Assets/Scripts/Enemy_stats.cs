using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_stats : MonoBehaviour
{
    public int health = 1;
    public float speed = 1;
    public WavesSO enemyType;
    public NavMeshAgent agent;
    private Settings settings;

    private void Awake() {
        health = enemyType.health;
        speed = enemyType.speed;
        agent.speed = speed;
        settings = GameObject.Find("/Main Camera").GetComponent<Settings>();

    }

    private void Update() {
        gameObject.GetComponent<Transform>().rotation = Quaternion.identity;
        GetComponent<Animator>().SetInteger("Health", health);

        GetComponent<AudioSource>().volume = settings.soundValue;
    }

    public void FixedUpdate() {
        if(agent.enabled == true){
            agent.SetDestination(new Vector3(225, -5.5f, 0));
        }

        if(transform.position.x >= 215){
            GameObject WavesManager = GameObject.Find("/WavesManager");
            WavesManager.GetComponent<Waves>().GiveScore(1);
            WavesManager.GetComponent<playerHealth>().GetDamage(enemyType.points);

            Destroy();
            
        }
    }

    public void TakeDamage(int damage){
        health -= damage;
        if(health <= 0){
            GetComponent<AudioSource>().Play(0);    
            if(gameObject.tag == "Enemy"){
                GameObject GoldManager = GameObject.Find("/GoldManager");
                GoldManager.GetComponent<Gold>().GiveGold(enemyType.gold);

                GameObject WavesManager = GameObject.Find("/WavesManager");
                WavesManager.GetComponent<Waves>().GiveScore(1);  
                WavesManager.GetComponent<playerHealth>().Killed();
            }
            agent.enabled = false;
            gameObject.tag = "Dead";

            if(gameObject.name == "E2(Clone)" | gameObject.name == "E3(Clone)" | gameObject.name == "E5(Clone)" | gameObject.name == "E7(Clone)" | gameObject.name == "E14(Clone)"){
                Invoke("Destroy", 1.5f);
            }
            else{
                Invoke("Destroy", 5f);
            }

            
            
        }
    }

    private void Destroy() {
        Destroy(gameObject);
    }

        

}


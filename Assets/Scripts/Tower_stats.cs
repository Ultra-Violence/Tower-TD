using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tower_stats : MonoBehaviour
{  
    [SerializeField] private BuildSO tower;
    [SerializeField] BulletSO activeBulletType;
    
    [SerializeField] private float rangeAttack;
    [SerializeField] private float speedAttack;
    [SerializeField] private int cost;
    [SerializeField] private bool towerAttack = false;

    private Vector2 towerPos;
    private Transform bulletPrefab;

    public bool buffTowerBool = false;
    private Settings settings;

    private void Awake() {
        rangeAttack = tower.rangeAttack;
        speedAttack = tower.speedAttack;
        cost = tower.cost;
        bulletPrefab = activeBulletType.prefab; 

        settings = GameObject.Find("/Main Camera").GetComponent<Settings>();

        } 

    void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(new Vector3(gameObject.GetComponent<Transform>().position.x, gameObject.GetComponent<Transform>().position.y, 0), rangeAttack);
    }

    private void FixedUpdate() {
        Vector2 towerPos = new Vector2(gameObject.GetComponent<Transform>().position.x, gameObject.GetComponent<Transform>().position.y);

        Collider2D[] towerCircleList = Physics2D.OverlapCircleAll(towerPos, rangeAttack);
                foreach(Collider2D enemys in towerCircleList){
                    if(Array.Exists(towerCircleList, enemys => enemys.tag == "Enemy") == true && towerAttack == false){

                        StartCoroutine(BulletsInst());
                    }
                    
            }   
    }


    IEnumerator BulletsInst(){
        if(gameObject.name != "T5(Clone)"){
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
        else{
            Instantiate(bulletPrefab, new Vector3(UnityEngine.Random.Range(transform.position.x - 5f, transform.position.x + 5f), UnityEngine.Random.Range(transform.position.y - 5f, transform.position.y + 5f), UnityEngine.Random.Range(transform.position.z - 5f, transform.position.z + 5f)), Quaternion.identity);
        }
        
        animations();
        GetComponent<AudioSource>().Play(0);
        towerAttack = true;
        yield return new WaitForSeconds(speedAttack);
        towerAttack = false;
    }
    
    private void animations(){
        if(gameObject.name == "T1(Clone)"){
            GetComponent<Animator>().Play("Base Layer.T1", 0, 0);
        }
        else if(gameObject.name == "T2(Clone)"){
            GetComponent<Animator>().Play("Base Layer.T2", 0, 0);
        }
        else if(gameObject.name == "T3(Clone)"){
            GetComponent<Animator>().Play("Base Layer.T3", 0, 0);
        }
        else if(gameObject.name == "T4(Clone)"){
            GetComponent<Animator>().Play("Base Layer.T4", 0, 0);
        }
        else if(gameObject.name == "T5(Clone)"){
            GetComponent<Animator>().Play("Base Layer.T5", 0, 0);
        }
        
    }

    public void buffTower(float bonusRange, float bonusSpeed){
        buffTowerBool = true;
        StartCoroutine(spawnUp());
        rangeAttack += bonusRange;
        speedAttack += bonusSpeed;
    }

    IEnumerator spawnUp(){
        Instantiate(tower.prefabUp, new Vector3(UnityEngine.Random.Range(gameObject.GetComponent<Transform>().position.x - 5f, gameObject.GetComponent<Transform>().position.x + 5f), UnityEngine.Random.Range(gameObject.GetComponent<Transform>().position.y - 5f, gameObject.GetComponent<Transform>().position.y + 5f), UnityEngine.Random.Range(gameObject.GetComponent<Transform>().position.z - 5f, gameObject.GetComponent<Transform>().position.z + 5f)), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        StartCoroutine(spawnUp());
    }

    private void Update() {
        GetComponent<AudioSource>().volume = settings.soundValue;
    }
        
}

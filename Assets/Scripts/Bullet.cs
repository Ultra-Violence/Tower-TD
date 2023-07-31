using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletSO activeType;
    [SerializeField] private BulletSO activeBoomType;
    [SerializeField] private float speed;

    private GameObject[] enemys;
    private Collider2D enemyCollider;
    [SerializeField] private GameObject closestEnemy = null;
    [SerializeField] private Vector3 closestEnemyPos;
    [SerializeField] private float distance;

    private Transform boomPrefab;
    private Vector2 pos;
    
    private Vector3 towerPos;
    private Vector3 bulletPos;

    public int damage;

    private void Awake() {
        towerPos = new Vector3(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);

        speed = activeType.speed;
        damage = activeType.damage;
        
        if(gameObject.name == "B2(Clone)"){
            boomPrefab = activeBoomType.boomPrefab;
        }
        

        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        Vector2 pos = new Vector2(gameObject.GetComponent<Transform>().position.x, gameObject.GetComponent<Transform>().position.y);
        float newDis = Mathf.Infinity;
        foreach(GameObject enemy in enemys){
            
            float enemyDis = Vector2.Distance(pos, new Vector2(enemy.GetComponent<Transform>().position.x, enemy.GetComponent<Transform>().position.y));
                    if (enemyDis < newDis)
                    {
                        closestEnemy = enemy;
                        newDis = enemyDis;
                    }
                    
        }
        
    }

    private void FixedUpdate() {
        if(gameObject.name != "B4(Clone)" | gameObject.name != "B2B(Clone)"){
            closestEnemyPos = closestEnemy.GetComponent<Transform>().position;
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y ), new Vector2(closestEnemyPos.x, closestEnemyPos.y), speed * Time.fixedDeltaTime); 
        }
    }

    private void Update() {
        if(closestEnemy == null) {
                bulletDestroy();
            
        }
        bulletPos = new Vector3(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);
        distance = Vector3.Distance(bulletPos, closestEnemyPos);

        if(distance < 5.2f & gameObject.name == "B1(Clone)"){
            bulletDestroy();
        }
        else if(distance < 5.2f & gameObject.name == "B2(Clone)"){
            createBoom();
        }
        else if(distance < 5.2f & gameObject.name == "B3(Clone)"){
            bulletDestroy();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy"){
            enemyCollider = other;
            if(gameObject.name == "B1(Clone)"){
            sendDamage();
        }
            else if(gameObject.name == "B3(Clone)"){
            sendDamage();
        }
            else if(gameObject.name == "B4(Clone)"){
            Invoke("sendDamage", 0.3f);
            Invoke("bulletDestroy", 0.5f); 
        }
        }
    } 

    private void sendDamage(){
        if(gameObject.name == "B4(Clone)"){
            Collider2D[] towerCircleList = Physics2D.OverlapCircleAll(towerPos, 25);
                foreach(Collider2D enemysInCircle in towerCircleList){
                    if(enemysInCircle.tag == "Enemy"){
                        enemysInCircle.GetComponent<Enemy_stats>().TakeDamage(damage);
                    }  
            }  
        }
        else{
            enemyCollider.GetComponent<Enemy_stats>().TakeDamage(damage);
        }
        
        
    }

    private void createBoom(){
        Instantiate(boomPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void bulletDestroy() {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoom : MonoBehaviour
{
    [SerializeField] private BulletSO activeType;
    private Settings settings;

    private float radius;
    private int damage;
    private Vector3 pos;

    private void Awake() {
        radius = activeType.boomRadius;
        damage = activeType.damage;
        settings = GameObject.Find("/Main Camera").GetComponent<Settings>();
        

        pos = new Vector3(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z );
    }  

    private void Start() {
            Collider2D[] boomList = Physics2D.OverlapCircleAll(pos, radius);
                foreach(Collider2D hitedEnemys in boomList){
                    if(hitedEnemys.tag == "Enemy"){
                        hitedEnemys.GetComponent<Enemy_stats>().TakeDamage(damage);
                        
                    }  
            }  
            Invoke("destroyBoom", 0.3f);
    } 

    private void destroyBoom(){
        Destroy(gameObject);
    }

    private void Update() {
        GetComponent<AudioSource>().volume = settings.soundValue;
    }

}

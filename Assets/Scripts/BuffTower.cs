using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffTower : MonoBehaviour
{
    [SerializeField] private BuildSO tower;
    [SerializeField] private float rangeAttack;
    private Settings settings;

    private void Awake() {
        rangeAttack = tower.rangeAttack;
        settings = GameObject.Find("/Main Camera").GetComponent<Settings>();
    }

    private void FixedUpdate() {
        Vector2 towerPos = new Vector2(gameObject.GetComponent<Transform>().position.x, gameObject.GetComponent<Transform>().position.y);

        Collider2D[] towerCircleList = Physics2D.OverlapCircleAll(towerPos, rangeAttack);
                foreach(Collider2D towers in towerCircleList){
                    if(towers.tag == "Tower" && towers.name != "T6(Clone)"){
                        if(towers.GetComponent<Tower_stats>().buffTowerBool == false){
                            towers.GetComponent<Tower_stats>().buffTower(5f, -1f);
                    }
                    }
                    
            }   
    }

    private void Update() {
        GetComponent<AudioSource>().volume = settings.soundValue;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Build : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] public BuildSO activeTowersType;
    [SerializeField] BuildSO T0;
    [SerializeField] private GameObject white;

    private GameObject GoldManager;

    private void Awake() {
        GoldManager = GameObject.Find("/GoldManager");
    }

    private void Update() {
        Vector3 mouseWorldPosition = camera.ScreenToWorldPoint(Input.mousePosition);    //коректне слідкування за мишою
            mouseWorldPosition.z = 0f;

        if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() ){
            if(CanSpawnBuilding(activeTowersType, mouseWorldPosition) && GoldManager.GetComponent<Gold>().goldScorePub >= activeTowersType.cost){
                
                GoldManager.GetComponent<Gold>().towerPrice(activeTowersType.cost);

                Instantiate(activeTowersType.prefab, mouseWorldPosition, Quaternion.identity);

            }
            
        }

        if(activeTowersType != T0){
            white.GetComponent<Transform>().position = mouseWorldPosition;
            white.SetActive(true);
            if(CanSpawnBuilding(activeTowersType, mouseWorldPosition)){
                white.GetComponent<SpriteRenderer>().color = Color.green;
            }
            else{
                white.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
        else{
            white.SetActive(false);
        }
    }

    public void SetActiveBuildingType(BuildSO buildingTypeSO){
        activeTowersType = buildingTypeSO;
    }

    public BuildSO GetActiveBuildingType(){
        return activeTowersType;
    }

    private bool CanSpawnBuilding(BuildSO buildingTypeSO, Vector3 position){
        BoxCollider2D buldingBoxCollider = buildingTypeSO.prefab.GetComponent<BoxCollider2D>();

        if (Physics2D.OverlapBox(position + (Vector3)buldingBoxCollider.offset, new Vector2(10f, 10f), 0) != null){
                return false;
            }
            else{
                return true;
            }
        
    }
}

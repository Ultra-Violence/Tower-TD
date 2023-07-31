using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildSelectUI : MonoBehaviour
{
    [SerializeField] private List<BuildSO> towersTypeSOList;
    [SerializeField] private Build build;
    [SerializeField] BuildSO T0;
    public GameObject Settings_HUD;

    private Dictionary<BuildSO, Transform> buildingBtnDictionary;

    

    private void Awake(){
        Transform buildingBtnTemplate = transform.Find("buildingBtnTemplate");
        buildingBtnTemplate.gameObject.SetActive(false);

        buildingBtnDictionary = new Dictionary<BuildSO, Transform>(); 

        int index = 0;

        foreach (BuildSO towerTypeSO in towersTypeSOList)
        {
            Transform buildingBtnTransform = Instantiate(buildingBtnTemplate, transform);
            buildingBtnTransform.gameObject.SetActive(true);

            buildingBtnTransform.GetComponent<RectTransform>().anchoredPosition += new Vector2(index * 150, 0);
            buildingBtnTransform.Find("image").GetComponent<Image>().sprite = towerTypeSO.sprite;
            buildingBtnTransform.Find("cost").GetComponent<Text>().text = towerTypeSO.cost.ToString();

            buildingBtnTransform.GetComponent<Button>().onClick.AddListener(() => {
                build.SetActiveBuildingType(towerTypeSO);
                UpdateSelectedVisual();
            });

            buildingBtnDictionary[towerTypeSO] = buildingBtnTransform;

            index++;
        }
    }

    private void Start() {
        UpdateSelectedVisual();
    }

    public void pressB(){
        build.SetActiveBuildingType(T0);
            foreach(BuildSO towerTypeSO in buildingBtnDictionary.Keys){
            buildingBtnDictionary[towerTypeSO].Find("selected").gameObject.SetActive(false);
            }
    }

    private void Update(){
        // if(Input.GetKeyDown(KeyCode.Escape)){
        //     if(build.activeTowersType == T0){
        //     Settings_HUD.SetActive(!Settings_HUD.activeInHierarchy);
        // }
        //     build.SetActiveBuildingType(T0);
        //     foreach(BuildSO towerTypeSO in buildingBtnDictionary.Keys){
        //     buildingBtnDictionary[towerTypeSO].Find("selected").gameObject.SetActive(false);
        // }
        // }
    }

    private void UpdateSelectedVisual(){
        foreach(BuildSO towerTypeSO in buildingBtnDictionary.Keys){
            buildingBtnDictionary[towerTypeSO].Find("selected").gameObject.SetActive(false);

        }

        BuildSO activeTowersType = build.GetActiveBuildingType();
        buildingBtnDictionary[activeTowersType].Find("selected").gameObject.SetActive(true);
    }
}

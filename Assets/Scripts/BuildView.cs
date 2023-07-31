using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildView : MonoBehaviour
{
    public GameObject BuildUI;
    public BuildSelectUI buildSelectUI;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.B)){
            BuildUI.SetActive(!BuildUI.activeInHierarchy);
            buildSelectUI.pressB();

        }
    }

    public void pressB(){
        BuildUI.SetActive(!BuildUI.activeInHierarchy);
        buildSelectUI.pressB();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedScale : MonoBehaviour
{
    [SerializeField] private playerHealth WavesManager;

    [SerializeField] private Text x1Text;
    [SerializeField] private Text x2Text;
    [SerializeField] private Text x4Text;
    [SerializeField] private Text x8Text;

    public void x1Speed(){
        if(WavesManager.gameStop == false){
            Time.timeScale = 1f;
            x1Text.color = Color.red;
            x2Text.color = Color.white;
            x4Text.color = Color.white;
            x8Text.color = Color.white;
        }
        
    }

    public void x2Speed(){
        if(WavesManager.gameStop == false){
            Time.timeScale = 2f;
            x2Text.color = Color.red;
            x1Text.color = Color.white;
            x4Text.color = Color.white;
            x8Text.color = Color.white;
        }
        
    }

    public void x4Speed(){
        if(WavesManager.gameStop == false){
            Time.timeScale = 4f;
            x4Text.color = Color.red;
            x1Text.color = Color.white;
            x2Text.color = Color.white;
            x8Text.color = Color.white;
        }
        
    }

    public void x8Speed(){
        if(WavesManager.gameStop == false){
            Time.timeScale = 8f;
            x8Text.color = Color.red;
            x1Text.color = Color.white;
            x2Text.color = Color.white;
            x4Text.color = Color.white;
        }
        
    }
}

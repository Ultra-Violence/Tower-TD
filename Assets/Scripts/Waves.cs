using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    [SerializeField] private List<WavesSO> EnemySOList;
    [SerializeField] private GameObject nextWaveButton;
    [SerializeField] private GameObject GameOver;
    [SerializeField] public int Level = 1;
    [SerializeField] private int Score = 0;
    [SerializeField] private int waveScale = 0;

    [SerializeField]public int levelPub => Level;
    public bool endWave = false;

    public void NextWaveButton() {
        Level++;
        StartCoroutine(SpawnEnemys());
        nextWaveButton.SetActive(false);
        endWave = false;
    }

    // public void WaveSelect(){
    //     for( int i = 1; i <= 50; i++){
    //         Instantiate(EnemySOList[Level - 1].prefab, new Vector3(-400,0,0), Quaternion.identity);
    //     }
    // }

    IEnumerator SpawnEnemys(){
        if(waveScale < 50){
            Instantiate(EnemySOList[Level - 2].prefab, new Vector3(-200,0,0), Quaternion.identity);
            waveScale++;
            yield return new WaitForSeconds(1.5f);
            StartCoroutine(SpawnEnemys());
        }
    }

    public void GiveScore(int scorePerUrit){
        Score += scorePerUrit;
    }

    private void Update() {
        if(Score >= 50){
            endWave = true;
            Score = 0;
            waveScale = 0;
        }

        if(endWave == true){
            nextWaveButton.SetActive(true);
        }

        
    }


}

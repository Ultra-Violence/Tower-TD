using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    [SerializeField] private int PlayerPoints = 50;
    [SerializeField] private int wavesPassed;
    [SerializeField] private int goldEarned;
    [SerializeField] private int enemysKilled = 0;
    [SerializeField] private GameObject GameOver;
    [SerializeField] private Waves waves;

    [SerializeField] private Text ViewWavesPassed;
    [SerializeField] private Text ViewGoldEarned;
    [SerializeField] private Text ViewEnemysKilled;

    [SerializeField] public bool gameStop = false;

    public void GetDamage(int points){
        PlayerPoints -= points;
        GetComponent<HealthView>().currentHealth -= points;
    }

    public void Killed(){
        enemysKilled++;
    }

    private void Update() {
        if(PlayerPoints <= 0 || waves.Level == 19){
            Time.timeScale = 0;
            gameStop = true;

            GameObject WavesManager = GameObject.Find("/WavesManager");
            GameObject GoldManager = GameObject.Find("/GoldManager");

            wavesPassed = WavesManager.GetComponent<Waves>().levelPub - 2;
            goldEarned = GoldManager.GetComponent<Gold>().goldEarned;

            ViewWavesPassed.text = "waves passed:" + wavesPassed;
            ViewGoldEarned.text = "gold earned:" + goldEarned;
            ViewEnemysKilled.text = "enemies killed:" + enemysKilled;

            GameOver.SetActive(true);
        }
    }

    public void againBtn(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void quitBtn(){
        Application.Quit();
    }
    


}

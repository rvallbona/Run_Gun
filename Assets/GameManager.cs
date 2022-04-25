using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    //int playerXP;
    //int playerCoins;
    public int score;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        score = 0;
    }
    void Update()
    {

    }
    //Score:
    public void IncreasePlayerScore(int value) { score += value; }
    public int GetPlayerScore() { return score; }
    //public void IncreasePlayerCoins(int value) { playerCoins += value; }
    //public int GetPlayerXP() { return playerXP; }
    //Pause;
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}

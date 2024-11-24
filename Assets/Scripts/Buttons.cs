using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;

public class Buttons : MonoBehaviour
{
    public TextMeshProUGUI coinsCounter;
    private int coins;
    public Button startButton;
    public Button optionsButton;
    public Button exitButton;
    public bool isGameActive;
    void Start()
    {
        coins = 0;
        UpdateCoins(0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main Game");
    }

    public void UpdateCoins(int scoreToAdd)
    {
        coins++;
        coinsCounter.text = "Coins: " + coins;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

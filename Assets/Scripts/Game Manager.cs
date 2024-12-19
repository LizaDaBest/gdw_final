using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody targetRb;
    public TextMeshProUGUI coinsCounter;
    public TextMeshProUGUI btnText;
    public TextMeshProUGUI superbtnText;
    public TextMeshProUGUI endgameTimer;
    public TextMeshProUGUI coinspersecond;
    // This is the slider object, do not use the TextMeshPro object, they are different.
    public UnityEngine.UI.Slider healthSlider;
    public float coins;
    public float coinTime;
    public GameObject coin;
    public bool isGameActive = false;
    private float spawnRate = 5.0f;
    private float zSpawnPos = -30;
    private GameManager gameManager;
    private float xRange = 65;
    private float ySpawnPos = -30;
    private float upgradeCost;
    private float superhitCost;
    private float coinPerSecond = 1;
    private float upgradeCount = 0;
    private float hitCount = 0;
    public float damageTime = 3;
    public GameObject Enemy;
    public float enemySpawnRate = 1.0f;
    public float timerseconds = 5.0f;
    public float minutes;
    public float seconds;
    public int currentCoinsClicked;
    private int secondsElapsed;

    void Start()
    {
        coins = 0;
        UpdateCoins(0);
        //StartCoroutine(UpdateTimer(0));
        StartCoroutine(CoinPassive());
        StartCoroutine(SpawnCoins());
        StartCoroutine(GainPerSec());
       // Time();
        isGameActive = true;
        upgradeCost = 5;
        superhitCost = 50;
        healthSlider.AddComponent<TextMeshProUGUI>();
        // Example of a call to your slider. Slider name . call (on a value change from some outside source) . AddListener (which is given a method as a parameter)
        // Example: AddListener(DecreaseHealth()); with DecreaseHealth being a public void? (maybe int), that decreases a count.;
        // healthSlider.onValueChanged.AddListener();
    }

    // coin related things

    public void UpdateCoins(float scoreToAdd)
    {
        coins += coinPerSecond;
        coins = UnityEngine.Mathf.Round(coins);
        coinsCounter.text = "Coins: " + coins;
    }

   // IEnumerator UpdateTimer(float scoreToAdd)
  //  {
      //  while (true)
       // {
            
         //   endgameTimer.text = "Time: " + minutes + ":" + seconds;

       // }
       
  //  }

    IEnumerator CoinPassive()
    {
        while (true)
        {
            yield return new WaitForSeconds(coinTime);
            UpdateCoins(coinPerSecond);
        }
    }

    //IEnumerator Time()
    //{
       // if (coins >= Mathf.Infinity)
       // {
         //   yield return new WaitForSeconds(timerseconds);
          //  SceneManager.LoadScene("Main Game");

       // }
   // }

    // spawns coins

    Vector3 RandomSpawnPos()
    {
        return new Vector3(UnityEngine.Random.Range(-xRange, xRange), ySpawnPos, zSpawnPos);
    }
    IEnumerator SpawnCoins()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate/(1+(hitCount*0.2f)));

            GameObject c = Instantiate(coin, RandomSpawnPos(), coin.transform.rotation);
            
        }

    } 
    // upgrade button
    public void Upgrade() 
    {
        if (coins >= upgradeCost)
        {
            upgradeCount++;
            coins -= upgradeCost;
            upgradeCost *= Mathf.Pow(2f, (upgradeCount / (2 + upgradeCount)));
            upgradeCost = UnityEngine.Mathf.Round(upgradeCost);
            btnText.text = ( "Upgrade Cost: " + upgradeCost);
            coinPerSecond += Mathf.Round(1.2f+(coinPerSecond/ (upgradeCount / 2)));
        }
    }
    // superhit cost
    public void SuperHit()
    {
        if (coins >= superhitCost)
        {
            hitCount++;
            coins -= superhitCost;
            superhitCost *= Mathf.Pow(2f, hitCount / (2 + hitCount));
            superhitCost = UnityEngine.Mathf.Round(superhitCost);
            superbtnText.text = ("Superhit Cost: " +  superhitCost);
        }
    }

    public IEnumerator GainPerSec()
    {

        while (true)
        {
            yield return new WaitForSeconds(1);
            secondsElapsed++;

        }
    }

    // slider health, damage, and enemy spawning
    //public void DecreaseHealth()
    //{
    //    while ((isGameActive == true) & (Enemy.gameObject == true))
    //    {
    //        if (healthSlider.value <= 0)
    //        {

    //            Destroy(healthSlider);
    //            Destroy(Enemy.gameObject);
    //            Respawn();

    //        }
    //        healthSlider.value -= damage;
    //        Damage();
    //    }
    //}
    //IEnumerator Damage()
    //{
    //    while (true) 
    //    {
    //        yield return new WaitForSeconds(damageTime);
    //    } 
    //}

    //IEnumerator Respawn()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(enemySpawnRate);
    //        RespawnEnemy();
    //    }
    //}

    //public void RespawnEnemy()
    //{
    //    healthSlider.value = healthSlider.value * damage;
    //    Instantiate(Enemy);
    //    Instantiate(healthSlider);
    //}

    void Update()
    {
        //StartCoroutine(Damage());
        coinspersecond.text = ("Coins Per Second: " + coinPerSecond);
    }
}

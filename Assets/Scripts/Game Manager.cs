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
    // This is the slider object, do not use the TextMeshPro object, they are different.
    public UnityEngine.UI.Slider healthSlider;
    public int coins;
    public float coinTime;
    public GameObject coin;
    public bool isGameActive;
    private float spawnRate = 5.0f;
    private float zSpawnPos = -10;
    private GameManager gameManager;
    private float xRange = 90;
    private float ySpawnPos = -30;
    private int upgradeCost;
    private int damage = 5;

    void Start()
    {
        coins = 0;
        UpdateCoins(0);
        StartCoroutine(CoinPassive());
        StartCoroutine(SpawnCoins());
        isGameActive = true;
        upgradeCost = 5;
        // Example of a call to your slider. Slider name . call (on a value change from some outside source) . AddListener (which is given a method as a parameter)
        // Example: AddListener(DecreaseHealth()); with DecreaseHealth being a public void? (maybe int), that decreases a count.;
        // healthSlider.onValueChanged.AddListener();
    }

    // coin related things

    public void UpdateCoins(int scoreToAdd)
    {
        coins++;
        coinsCounter.text = "Coins: " + coins;
    }

    IEnumerator CoinPassive()
    {
        while (true)
        {
            yield return new WaitForSeconds(coinTime);
            UpdateCoins(1);
        }
    }

    // shoot coins up for player to click on

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos, zSpawnPos);
    }
    IEnumerator SpawnCoins()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);

            GameObject c = Instantiate(coin, RandomSpawnPos(), coin.transform.rotation);
            
        }

    } 

    public void Upgrade() 
    {
        if (coins > upgradeCost)
        {
            coins -= upgradeCost;
            upgradeCost *= 2;
            btnText.text = ( "Upgrade Cost: " + upgradeCost);
            damage += upgradeCost;
        }
    }
}

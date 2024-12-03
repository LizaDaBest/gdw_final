using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody targetRb;
    public TextMeshProUGUI coinsCounter;
    private int coins;
    public float coinTime;
    public GameObject coin;
    public bool isGameActive;
    private float spawnRate = 10.0f;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 50;
    private float xRange = 90;
    private float ySpawnPos = -20;
    // private float zSpawnPos = -90;
    private GameManager gameManager;
    public float destroyTime = 5.0f;
    void Start()
    {
        coins = 0;
        UpdateCoins(0);
        StartCoroutine(CoinPassive());
        StartCoroutine(SpawnCoins());
        // StartCoroutine(DeleteCoins());

       // targetRb = GetComponent<Rigidbody>();
       // targetRb.AddForce(RandomForce(), ForceMode.Impulse);
       // targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
       // transform.position = RandomSpawnPos();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    IEnumerator SpawnCoins()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);

            GameObject c = Instantiate(coin, RandomSpawnPos(), coin.transform.rotation);
            Rigidbody rb = c.GetComponent<Rigidbody>();
            rb.AddForce(RandomForce(), ForceMode.Impulse);
            rb.AddTorque(new Vector3 (RandomTorque(), RandomTorque(), RandomTorque()));
            OnMouseDown();
        }

    } 

    // IEnumerator DeleteCoins()
   // {
        
      
  //  }

    private void OnMouseDown()
    {
        if (isGameActive)
        {
            coins+= 30;
            Destroy(coin);
        }
    }

    void Update()
    {
        
    }
}

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
    private float spawnRate = 5.0f;
    private float zSpawnPos = -10;
    private GameManager gameManager;
    private float xRange = 90;
    private float ySpawnPos = -30;
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

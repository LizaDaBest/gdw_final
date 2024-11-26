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
    private float spawnRate = 30.0f;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 250;
    private float ySpawnPos = 50;
    private GameManager gameManager;
    void Start()
    {
        coins = 0;
        UpdateCoins(0);
        StartCoroutine(CoinPassive());
        StartCoroutine(SpawnCoins());

        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
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

            Instantiate(coin);
            OnMouseDown();
        }

    }

    private void OnMouseDown()
    {
        if (isGameActive)
        {
            coins+= 30;
        }
    }

    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody rb;
    private float minSpeed = 50;
    private float maxSpeed = 100;
    private float maxTorque = 50;
    private GameManager gameManager;
    private int upgradeCost;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(RandomForce(), ForceMode.Impulse);
        rb.AddTorque(RandomForce(), ForceMode.Impulse);
        gameManager = GameObject.FindAnyObjectByType<GameManager>();
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -40)
        {
            Destroy(this.gameObject);
        }
        
    }

    private void OnMouseDown()
    {
        //Debug.Log(gameManager.isGameActive);
        if (gameManager.isGameActive)
        {
            gameManager.coins += 30;
            Destroy(this.gameObject);
        }
    }
}

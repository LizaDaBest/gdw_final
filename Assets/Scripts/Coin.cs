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
    public float seconds = 5.0f;
   // private float count = 0;
    private float coinPerSecond = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(RandomForce(), ForceMode.Impulse);
        rb.AddTorque(RandomForce(), ForceMode.Impulse);
        gameManager = GameObject.FindAnyObjectByType<GameManager>();
      //  StartCoroutine(CoinValue());
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
            gameManager.coins += 30 + Mathf.Pow(2f,3*coinPerSecond);
            Destroy(this.gameObject);
            
        }
    }

    //IEnumerator CoinValue()
   // {
      //  if (this.gameObject == true)
     //   {
           // yield return new WaitForSeconds(seconds);
         //   Debug.Log("Woah!");
         //  yield return gameManager.coins *= Mathf.Pow(2f, count / (2 + count));

       // }
    //}
}

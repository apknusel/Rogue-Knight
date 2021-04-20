using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue;
    Rigidbody2D rb;
    private int timer = 500;

    public void start()
    {
        rb = GetComponent<Rigidbody2D>();
        for (int i = 0; i<timer; i++)
        {
            rb.AddForce(transform.forward);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CoinManager.instance.ChangeScore(coinValue);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopScript : MonoBehaviour
{
    public int cost;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && CoinManager.instance.getScore() >= cost)
        {
            CoinManager.instance.ChangeScore(-cost);
            Destroy(gameObject);
        }
    }
}

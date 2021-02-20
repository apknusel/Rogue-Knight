using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;
    public Text text;
    int health;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            ChangeHealth(player.GetComponent<PlayerController>().health());
        }
    }

    public void ChangeHealth(int amount)
    {
        health += amount;
        text.text = "" + health.ToString();
    }
}
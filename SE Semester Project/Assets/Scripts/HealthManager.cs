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
        DontDestroyOnLoad(this);
        
    }

    void Update()
    {
        if (instance == null)
        {
            instance = this;
            if (player != null)
            {
                ChangeHealth(player.GetComponent<PlayerController>().health());
            }
        }
        if (player == null)
        {
            GameObject.FindGameObjectWithTag("Player");
        }
    }

    public void ChangeHealth(int amount)
    {
        health += amount;
        text.text = "" + health.ToString();
    }

    public void setText(Text newText)
    {
        text = newText;
    }
    
    public void setPlayer(GameObject newPlayer)
    {
        player = newPlayer;
    }
}
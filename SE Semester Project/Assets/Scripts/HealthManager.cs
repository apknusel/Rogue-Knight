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

    void FixedUpdate()
    {
        health = player.GetComponent<PlayerController>().health();
        text.text = "" + health.ToString();
    }

    public void ChangeHealth(int amount)
    {
        health += amount;
        Debug.Log("change");
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
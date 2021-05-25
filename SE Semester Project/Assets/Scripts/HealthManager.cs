using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;
    public Text text;
    float health;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
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
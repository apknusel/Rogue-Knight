using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SetInstances : MonoBehaviour
{
    private GameObject LevelManager;
    LevelManager Level;
    private GameObject HealthManager;
    HealthManager Health;
    private GameObject CoinManager;
    CoinManager Coin;

    private int Waves;
    private int TotalEnemies;
    public GameObject Player;
    public Vector2 Width;
    public Vector2 Length;


    private Text CoinText;
    private Text HealthText;

    private int ran = 0;

    // Start is called before the first frame update
    void Start()
    {
        TotalEnemies = Random.Range(3, 22);
        if (SceneManager.GetActiveScene().buildIndex <= 4)
        {
            Waves = 0;
        }
        else
        {
            Waves = Random.Range(1, 6);
        }
        CoinText = GameObject.Find("Coin Text").GetComponent<Text>();
        HealthText = GameObject.Find("Health Text").GetComponent<Text>();
        Level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        Health = GameObject.Find("HealthManager").GetComponent<HealthManager>();
        Coin = GameObject.Find("CoinManager").GetComponent<CoinManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ran == 0)
        {
            Level.setWaves(Waves);
            Level.setEnemies(TotalEnemies);
            Level.setWidth(Width);
            Level.setLength(Length);
            Health.setPlayer(Player);
            Health.setText(HealthText);
            Coin.setText(CoinText);
            ran = 1;
        }

    }
}

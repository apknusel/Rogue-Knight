﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int waves;
    public int totalEnemies;
    public GameObject enemy;
    public GameObject player;
    public Vector2 spawnWidth;
    public Vector2 spawnLength;
    public Vector2 playerPosition;

    private int enemiesLeft;
    private int entered = 0;

    public void Awake()
    {
        Instantiate(player, new Vector3(playerPosition.x,playerPosition.y,0),transform.rotation);
        spawnEnemies();
    }

    public void FixedUpdate()
    {
        if (waves != 0)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
            enemiesLeft = enemies.Length;
            if (enemiesLeft == 0)
            {
                totalEnemies -= totalEnemies / waves;
                waves -= 1;
                spawnEnemies();
            }
        }
    }

    private void spawnEnemies()
    {
        if (waves != 0)
        {
            for (int i = 0; i < totalEnemies / waves; i++)
            {
                Instantiate(enemy, new Vector3(Random.Range(spawnLength.x, spawnLength.y), Random.Range(spawnWidth.x, spawnWidth.y), 0), transform.rotation);
            }
        }
    }


    public void OnTriggerEnter2D(Collider2D Player)
    {
        entered = 1;
    }
    
    public void Update()
    {
        if (entered == 1 && waves == 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(sceneBuildIndex: 1);
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }

    public void Exit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
    
}

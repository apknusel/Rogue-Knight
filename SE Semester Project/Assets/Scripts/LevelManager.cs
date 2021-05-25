using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int waves;
    public int totalEnemies;
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject player;
    public Vector2 spawnWidth;
    public Vector2 spawnLength;
    public Vector2 playerPosition;

    private int enemiesLeft;

    void Start()
    {
        DontDestroyOnLoad(this);
        
    }

    private int spawn = 1;
    private int level = 2;
    private int level2 = 2;
    public float[] stats;

    public void FixedUpdate()
    {
        if (spawn == 0)
        {
            Instantiate(player, new Vector3(playerPosition.x, playerPosition.y, 0), transform.rotation);
            spawnEnemies();
            spawn = 1;
        }
        level = SceneManager.GetActiveScene().buildIndex;
        if (level != level2 && level > 2)
        {
            spawn = 0;
            level2 = level;
        }
        
        if (waves != 0)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
            GameObject[] enemies2 = GameObject.FindGameObjectsWithTag("enemy2");
            enemiesLeft = enemies.Length + enemies2.Length;
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
                int num = Random.Range(1, 3);
                if (num == 1)
                {
                    Instantiate(enemy, new Vector3(Random.Range(spawnLength.x, spawnLength.y), Random.Range(spawnWidth.x, spawnWidth.y), 0), transform.rotation);
                }
                if (num == 2)
                {
                    Instantiate(enemy2, new Vector3(Random.Range(spawnLength.x, spawnLength.y), Random.Range(spawnWidth.x, spawnWidth.y), 0), transform.rotation);
                }
            }
        }
    }
    public void Update()
    {
        
        if ( waves == 0)
        {
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                int num = Random.Range(5, 7);
                stats = player.GetComponent<PlayerController>().getStats();
                Debug.Log(stats[1] + " "+ stats[2]);
                SceneManager.LoadScene(sceneBuildIndex: num);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                stats = player.GetComponent<PlayerController>().getStats();
                Debug.Log(stats);
                SceneManager.LoadScene(sceneBuildIndex: 4);
            }
        }
    }

    public float[] getStats()
    {
        return stats;
    }

    public void Restart()
    {
        SceneManager.LoadScene(sceneBuildIndex: 3);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void setWaves(int num)
    {
        waves = num;
    }

    public void setEnemies(int num)
    {
        totalEnemies = num;
    }

    public void setWidth(Vector2 w)
    {
        spawnWidth = w;
    }

    public void setLength(Vector2 L)
    {
        spawnLength = L;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int waves;
    public int totalEnemies;
    public GameObject enemy;

    private int enemiesLeft;
    private int entered = 0;

    public void Start()
    {
        spawnEnemies();
    }

    public void FixedUpdate()
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

    private void spawnEnemies()
    {
        for (int i = 0; i < totalEnemies / waves; i++)
        {
            Instantiate(enemy, new Vector3(Random.Range(-15, 8), Random.Range(-3, 8), 0), transform.rotation);
        }
    }


    public void OnTriggerEnter2D(Collider2D Player)
    {
        entered = 1;
    }
    
    void Update()
    {
        if (entered == 1 && waves == 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(sceneBuildIndex: 1);
            }
        }
    }
    
}

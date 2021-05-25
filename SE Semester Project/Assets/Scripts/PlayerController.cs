using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    public Text HealthText;
    public float currentHealth = 100;
    public float maxHealth = 100;
    public float Damage;
    public float[] NewStats;
    public float speed;

    public Animator animator;

    Vector2 movement;

    GameObject LevelManager;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Start()
    {
        NewStats = LevelManager.GetComponent<LevelManager>().getStats();
        if (NewStats != null)
        {
            setStats(NewStats);
        }
        Debug.Log(NewStats);
        HealthText.text = ""+100;
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x*speed,movement.y*speed);
        
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(sceneBuildIndex: 2);
        }
    }

    public void setText(Text t)
    {
        HealthText = t;
    }

    public float health()
    {
        return currentHealth;
    }

    public void changeHealth(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0 , maxHealth);
        HealthText.text = "" + currentHealth;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Hearts"))
        {
            Destroy(other.gameObject);
            changeHealth(10);
        }
        if (other.gameObject.CompareTag("firerate"))
        {
            GetComponent<shootScript>().firerateUpgrade();
        }
        if (other.gameObject.CompareTag("speed"))
        {
            speed *= 1.05f;
        }
        if (other.gameObject.CompareTag("damage"))
        {
            Damage += 5;
        }
        if (other.gameObject.CompareTag("health"))
        {
            maxHealth += 10;
            currentHealth += 50;
        }
    }

    public float getDamage()
    {
        return Damage;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            changeHealth(-1 * collision.gameObject.GetComponent<Monster1Controller>().getDamage());
        }
        if (collision.gameObject.CompareTag("enemy2"))
        {
            changeHealth(-1 * collision.gameObject.GetComponent<Monster2Controller>().getDamage());
        }
    }

    public float[] getStats()
    {
        float[] stats = { currentHealth, maxHealth, Damage, speed };
        Debug.Log(stats[1]+" " +stats[2]);
        return stats;
    }

    public void setStats(float[] stats)
    {
        currentHealth = stats[0];
        maxHealth = stats[1];
        Damage = stats[2];
        speed = stats[3];
    }

    public void setLevelManager(GameObject obj)
    {
        LevelManager = obj;
    }
}
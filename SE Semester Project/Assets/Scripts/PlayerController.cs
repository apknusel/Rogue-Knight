using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    public Text HealthText;
    public int currentHealth = 0;
    public int maxHealth = 100;
    public int Damage;

    public float speed = 3.0f;

    public Animator animator;

    Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        HealthText.text = "" + currentHealth;
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x*speed,movement.y*speed);
        
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (HealthText == null)
        {
            HealthText = GameObject.Find("Health Text").GetComponent<Text>();
        }

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(sceneBuildIndex: 2);
        }
    }

    public int health()
    {
        return currentHealth;
    }

    public void changeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0 , maxHealth);
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

    public int getDamage()
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
}
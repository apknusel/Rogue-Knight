using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    public int currentHealth;
    private Text HealthText;
    public int maxHealth = 200;
    public int Damage;

    public float speed = 3.0f;

    public Animator animator;

    Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = 100;
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        rb.velocity= new Vector2(movement.x*speed,movement.y*speed);
        
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        animator.SetFloat("Look X", movement.x);
        animator.SetFloat("Look Y", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (HealthText == null)
        {
            HealthText = GameObject.FindWithTag("Text").GetComponent<Text>();
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
    }

    public int getDamage()
    {
        return Damage;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("Damaged!");
            changeHealth(-1 * collision.gameObject.GetComponent<Monster1Controller>().getDamage());
        }
    }
}
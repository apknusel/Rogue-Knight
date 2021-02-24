using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    int currentHealth;

    public float speed = 3.0f;
    public int maxHealth = 100;

    public Animator animator;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = 10;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        animator.SetFloat("Look X", movement.x);
        animator.SetFloat("Look Y", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
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
        }
    }
}
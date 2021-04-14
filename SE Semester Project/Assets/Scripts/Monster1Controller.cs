using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster1Controller : MonoBehaviour
{
    private Animator myAnim;
    private Transform target;
    //public Transform homePos;
    public float speed;
    public float maxRange;
    public float minRange;
    public int currentHealth;
    public int maxHealth;
    public GameObject coin;
    public int Damage;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        myAnim = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
        {
            FollowPlayer();
        }
        else if (Vector3.Distance(target.position, transform.position) >= maxRange)
        {
            //GoHome();
        }
        if (currentHealth <= 0)
        {
            Instantiate(coin,transform.position,transform.rotation);
            Object.Destroy(this.gameObject);
        }
    }

    public void FollowPlayer()
    {
        myAnim.SetBool("isMoving", true);
        myAnim.SetFloat("moveX", (target.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void changeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth);
    }
    /*
    public void GoHome()
    {
        //myAnim.SetFloat("moveX", (homePos.position.x - transform.position.x));
        //myAnim.SetFloat("moveY", (homePos.position.y - transform.position.y));
        //transform.position = Vector3.MoveTowards(transform.position, homePos.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, homePos.position) == 0)
        {
            myAnim.SetBool("isMoving", false);
        }
    }*/

    public int getDamage()
    {
        return Damage;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            changeHealth(10);
        }
    }
}

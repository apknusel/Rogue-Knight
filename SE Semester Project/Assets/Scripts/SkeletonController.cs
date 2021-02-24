using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public Animator animator;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("distance", Vector2.Distance(transform.position, target.position));
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}

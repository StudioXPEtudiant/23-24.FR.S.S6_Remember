using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChasingAI : MonoBehaviour
{
    private Transform target;
    public float speed;
    private Animator animator;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        Vector2 moveDir = (transform.position - target.position).normalized;

        animator.SetFloat("MoveX", moveDir.x);
        animator.SetFloat("MoveY", moveDir.y);
        animator.SetBool("IsMoving", moveDir != Vector2.zero);
    }
}


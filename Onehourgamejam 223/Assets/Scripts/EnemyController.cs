﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 lastPos = new Vector3(0, 0, 0);
    private GameObject player;
    public float moveSpeed;
    public float jumpForce;
    public float bulletSpeed;

    public GameObject bulletPrefab;

    void Start()
    {
        player = GameObject.Find("Player");
    }
    
    void Update()
    {
        MoveToPlayer();
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position * transform.localScale.x, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed * transform.localScale.x, 0);
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForce));
    }

    void MoveToPlayer()
    {
        if (player.transform.position.x > transform.position.x)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }

        if (lastPos == transform.position)
        {
            Jump();
        }

        lastPos = transform.position;
    }
}

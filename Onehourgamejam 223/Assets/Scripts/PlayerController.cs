using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float moveSpeed = 1;
    public bool onGround = true;
    public float jumpForce = 1;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        int horizontal = 0;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            horizontal = -1;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            horizontal = 1;
        }

        _rb.velocity = new Vector2(horizontal * moveSpeed, _rb.velocity.y);

        CheckForGround();

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && onGround)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
            onGround = false;
        }
    }

    private void CheckForGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position - new Vector3(0, -1.5f), Vector2.down);

        Debug.Log(hit.collider.gameObject.name);

        if (hit.collider != null)
        {
            onGround = true;
        }
    }
}

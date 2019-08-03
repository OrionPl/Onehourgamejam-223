using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float moveSpeed = 1;
    public bool onGround = true;
    public float jumpForce = 1;
    private GameObject cam;
    private Animator animator;
    private bool right = true;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        cam = Camera.main.gameObject;
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        Movement();
        Cam();
    }

    private void Movement()
    {
        int horizontal = 0;
        bool moved = false;
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            horizontal = -1;
            moved = true;
            right = false;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            horizontal = 1;
            moved = true;
            right = true;
        }

        if (right)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1 , 1, 1);
        }

        _rb.velocity = new Vector2(horizontal * moveSpeed, _rb.velocity.y);

        if (moved)
        {
            animator.Play("Walking Anim");
        }
        else
        {
            animator.Play("Idle Anim");
        }

        CheckForGround();

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && onGround)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
            onGround = false;
        }
    }

    private void CheckForGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position - new Vector3(0, 1.5f), Vector2.down);

        Debug.Log(hit.collider.gameObject.name);

        
        if (hit.collider != null)
        {
            onGround = true;
        }
    }

    private void Cam()
    {
        cam.transform.position = new Vector3(transform.position.x, 0, -20);
    }

    public void GameOver()
    {
        Destroy(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Fug");
    }
}

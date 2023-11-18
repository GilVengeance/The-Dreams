using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpSpeed = 10f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int maxJumpCount = 2;

    private bool isGrounded;
    private int jumpCount;


    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            Debug.Log("Grounded!");
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            Debug.Log("Jumping!");
            isGrounded = false;
        }
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 direction = new Vector2(horizontal, 0);
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        if (jumpCount >= maxJumpCount)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 jumpDirection = new Vector2(0, 1);
            rb.velocity = jumpDirection * jumpSpeed;
            jumpCount++;
        }
    }
}

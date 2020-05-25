using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    Rigidbody2D rb2D;
    private Vector2 moveDirection;
    public Animator playerAnimation;
    bool isJumping;

    private void Start()
    {
        isJumping = false;
        rb2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        moveSpeed /= 2;
        BlackBoard.playerUI.playerEnergy -= 3;
        playerAnimation.SetBool("isJumping",true);
    }

    void FixedUpdate()
    {
        float horizontalMove = Input.GetAxis("Horizontal") * moveSpeed;
        moveDirection = new Vector2(horizontalMove, 0);
        playerAnimation.SetFloat("Speed", Mathf.Abs(horizontalMove));
        Vector3 v= transform.TransformDirection(moveDirection) * moveSpeed;
        //rb2D.MovePosition(rb2D.position + new Vector2(v.x,v.y));
        rb2D.AddForce(new Vector2(v.x, v.y));
        if (horizontalMove != 0)
        {
            BlackBoard.playerUI.playerEnergy -= 1 * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D player)
    {
        if (player.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            playerAnimation.SetBool("isJumping", false);
        }
    }
    private void OnCollisionStay2D(Collision2D player)
    {
        if (player.gameObject.CompareTag("Ground"))
        {
            moveSpeed = 7.5f;
        }
    }
    private void OnCollisionExit2D(Collision2D player)
    {
        if (player.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
}

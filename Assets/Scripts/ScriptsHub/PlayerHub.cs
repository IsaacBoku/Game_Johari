using Autodesk.Fbx;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHub : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody2D rb;
    private Animator ani;


    [Header("Movimiento")]
    public float speed;
    public float jumpForce;
    public float wallSlideSpeed;
    public int facingDir = 1;

    [Header("Wall")]
    public Transform wallCheck;
    public float wallCheckDistance;

    [Header("Booleanos")]
    public bool isGround = true;
    public bool canDoubleJump = false;
    public bool canUseDoubleJump = false;
    public bool isTouchingWall = false;

    [Header("Layers")]
    public LayerMask isWhatGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsWallDetected())
        {
            ani.SetBool("WallDu", true);
            ani.SetBool("Jump", false);
        }
        Movimiento();
        WallDumbling();
        Jump();
        Debug.Log(IsWallDetected());
        if (rb.velocity.y == 0)
        {
            ani.SetBool("Jump",false);
            ani.SetBool("WallDu", false);
        }
        ani.SetFloat("yVelocity", rb.velocity.y);
        if (rb.velocity.y > 0)
            ani.SetBool("Jump", true);

    }

    public void Movimiento()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        if (moveHorizontal > 0)
            transform.localScale = new Vector2(1, 1);
        if(moveHorizontal < 0)
            transform.localScale = new Vector2(-1, 1);

        rb.velocity = new Vector2(moveHorizontal*speed, rb.velocity.y);
    }
    public void WallDumbling()
    {
        if (isTouchingWall && !isGround)
        {

            rb.velocity = new Vector2(rb.velocity.x, -wallSlideSpeed);

        }

    }
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGround)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                isGround = false;
                canDoubleJump = canUseDoubleJump;

            }
            else if(canDoubleJump)
            {
                 rb.velocity = new Vector2(rb.velocity.x,jumpForce);
                canDoubleJump= false;
            }
            else if (isTouchingWall)
            {
                rb.velocity = new Vector2(-rb.velocity.y * speed, jumpForce);

                isTouchingWall = false;
            }

        }
    }
    public bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right*facingDir, wallCheckDistance, isWhatGround);

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGround = true;
            canDoubleJump = false;
        }
        else if(collision.gameObject.tag == "Wall")
        {
            isTouchingWall = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
            isGround = false;
        else if(collision.gameObject.tag == "Wall")
            isTouchingWall = false;
    }

}

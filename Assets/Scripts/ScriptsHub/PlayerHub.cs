
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHub : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody2D rb;
    private Animator ani;


    [Header("Movimiento")]
    protected float xInput;
    protected float yInput;
    public float moveSpeed;
    public float jumpForce;
    public float wallSlideSpeed;
    public int facingDir { get; private set; } = 1;
    bool facilRight = true;

    protected float stateTimer;

    [Header("Booleanos")]
    public bool isGround = true;
    public bool canDoubleJump = false;
    public bool canUseDoubleJump = false;
    public bool isTouchingWall = false;

    [Header("Collision info")]
    [SerializeField] Transform wallCheck;
    [SerializeField] float wallCheckDistance;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckDistance;
    public LayerMask isWhatGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        stateTimer -= Time.deltaTime;
        Movimiento();
        WallDumbling();
        Jump();
        Animations();
    }

    public void Animations()
    {

        if (IsWallDetected())
        {
            ani.SetBool("WallDu", true);
            ani.SetBool("Jump", false);
            ani.SetBool("Walk", false);
        }
        if (rb.velocity.y == 0)
        {
            ani.SetBool("Jump",false);
            ani.SetBool("WallDu", false);
            ani.SetBool("Walk", false);
        }
        if (rb.velocity.y > 0)
        {
            ani.SetBool("Jump", true);
            ani.SetBool("Walk", false);
        }
        if(xInput != 0 && IsGroundDetected() && !IsWallDetected())
        {
            ani.SetBool("Walk",true);
            ani.SetBool("Jump", false);
        }
        if(xInput == 0)
            ani.SetBool("Walk", false);
    }

    public void Movimiento()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        ani.SetFloat("yVelocity", rb.velocity.y);

        SetVelocity(xInput*moveSpeed,rb.velocity.y);
        if(xInput == 0|| IsWallDetected())
        {
            ani.SetBool("Jump", false);
            ani.SetBool("WallDu", false);
        }

    }
    public void WallDumbling()
    {

        if (IsWallDetected()) 
        {
            if (xInput != 0 && facingDir != xInput)
                ani.SetBool("WallDu", false);
            if (yInput < 0)
            rb.velocity = new Vector2(0, rb.velocity.y);
            else
            rb.velocity = new Vector2(0, rb.velocity.y * .7f);
        }
        
    }
    public void WallJump()
    {



    }
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            if (IsGroundDetected())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                canDoubleJump = canUseDoubleJump;

            }
            else if(canDoubleJump)
            {
                 rb.velocity = new Vector2(rb.velocity.x,jumpForce);
                canDoubleJump= false;
            }
            /*else if (isTouchingWall)
            {
                if (IsWallDetected()) 
                { 

                   
                    rb.velocity = new Vector2(-rb.velocity.x, jumpForce);
                    


                }
                isTouchingWall = false;
            }*/
            else if(IsWallDetected())
            {
                SetVelocity(wallSlideSpeed * -facingDir, jumpForce);
                    ani.SetBool("Jump", true);
            }

        }
    }
    public virtual bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right*facingDir, wallCheckDistance, isWhatGround);
    public virtual bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, isWhatGround);

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
    }

    #region Velocity
    public void ZeroVelocity() => rb.velocity = new Vector2(0, 0);
    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        FlipController(_xVelocity);
    }
    #endregion
    #region Flip
    public virtual void Flip()
    {
        facingDir = facingDir * -1;
        facilRight = !facilRight;
        transform.Rotate(0, 180, 0);
    }
    public virtual void FlipController(float _x)
    {
        if (_x > 0 && !facilRight)
            Flip();
        else if (_x < 0 && facilRight)
            Flip();
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerIntro : MonoBehaviour
{
    float cooldown = 2;
    public float time = 0;
    float finalTime = 20f;

    public GameObject marcos;

    public Animator volumeAnimator;

    public float speed = 12;
    float horizontalInput;

    int vidaMax = 3;
    int vidaActual;
    [Header("Components")]
    private Rigidbody2D rb;
    private Animator ani;

    [Header("Movimiento")]
    protected float xInput;
    protected float yInput;
    public float moveSpeed;

    public GameObject[] vidas;

    public int facingDir { get; private set; } = 1;
    bool facilRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        vidaActual = vidaMax;
    }

    // Update is called once per frame
    void Update()
    {

        Movimiento();
        CoolDown();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            vidaActual -= 1;

            if(vidaActual == 2)
            {
                vidas[0].SetActive(false);
                volumeAnimator.SetTrigger("Damage1");
            }
            else if(vidaActual == 1)
            {
                vidas[1].SetActive(false);
                volumeAnimator.SetTrigger("Damage2");
            }
            else if(vidaActual <= 0)
            {
                vidas[2].SetActive(false);
            }

            Destroy(other.gameObject);
        }
    }

    public void Movimiento()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        SetVelocity(xInput * moveSpeed, rb.velocity.y);
        if (xInput != 0 )
        {
            ani.SetBool("Walk", true);
        }
        if (xInput == 0)
            ani.SetBool("Walk", false);


    }
    void CoolDown()
    {
        time = Time.time + cooldown;

        if(time >= finalTime)
        {
            CambioVelocidad();
        }
    }

    void CambioVelocidad()
    {
        moveSpeed -= Time.deltaTime;

        if (moveSpeed <= 2)
        {
            moveSpeed = 2;
        }
    }
    public void ZeroVelocity() => rb.velocity = new Vector2(0, 0);
    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        FlipController(_xVelocity);
    }

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
}

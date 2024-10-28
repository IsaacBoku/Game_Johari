using Autodesk.Fbx;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHub : MonoBehaviour
{
    public float speed = 13f;
    public float jumpForce = 1000f;
    public bool isGrounded = true;
    Rigidbody2D rb;

    public float jumpForce2 = 2000f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }

    public void Movimiento()
    {
        transform.Translate(Vector2.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

        if (other.gameObject.tag == "Trampolin" && isGrounded == true)
        {
            rb.AddForce(Vector2.up * jumpForce);
            isGrounded = false;
        }

        if (other.gameObject.tag == "Trampolin" && isGrounded == false)
        {
            rb.AddForce(Vector2.up * jumpForce2);
            isGrounded = false;
        }
    }
}

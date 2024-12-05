using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaidaPlataforma : MonoBehaviour
{
    float fallDelay = 2f;
    float destroyDelay = 2.5f;
    public Transform respawn;

    bool falling = false;

    public Rigidbody2D rb;
    Animator ani;

    private void Start()
    {
        ani = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (falling)
        {
            return;
        }

        if (collision.transform.tag == "Player")
        {
            StartCoroutine(StartFall());
        }
    }

    private IEnumerator StartFall()
    {
        falling = true;
        ani.SetBool("Fall", true);

        yield return new WaitForSeconds(fallDelay);

        ani.SetBool("Fall", false);
        rb.bodyType = RigidbodyType2D.Dynamic;
        Invoke("Respawn", destroyDelay);
    }

    public void Respawn()
    {
        falling = false;
        gameObject.transform.localPosition = respawn.position;
        rb.bodyType = RigidbodyType2D.Static;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaidaPlataforma : MonoBehaviour
{
    float fallDelay = 1.5f;
    float destroyDelay = 2.5f;
    public Transform respawn;

    bool falling = false;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

        yield return new WaitForSeconds(fallDelay);

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

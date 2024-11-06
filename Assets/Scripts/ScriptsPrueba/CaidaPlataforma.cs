using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaidaPlataforma : MonoBehaviour
{
    float fallDelay = 1f;
    float destroyDelay = 2f;

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

        StartCoroutine(StartFall());
    }

    private IEnumerator StartFall()
    {
        falling = true;

        yield return new WaitForSeconds(fallDelay);

        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyDelay);
    }
}

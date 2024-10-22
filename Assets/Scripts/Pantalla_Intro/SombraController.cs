using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SombraController : MonoBehaviour
{
    public float speed = .3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= 9.5f)
        {
            transform.position = new Vector3(0, 9.5f, 0);
        }
        else
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedesLaterales : MonoBehaviour
{
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }

    private void Movimiento()
    {
        if(transform.position.x >= -3.3f && gameObject.tag == "Izq")
        {
            transform.position = new Vector3(-3.3f, -3.54f, 0);
        }
        else if(transform.position.x <= 3.3f && gameObject.tag == "Der")
        {
            transform.position = new Vector3(3.3f, -3.54f, 0);
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }
}

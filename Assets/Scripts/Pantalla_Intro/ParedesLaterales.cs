using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedesLaterales : MonoBehaviour
{
    public float speed = 5f;

    float cooldown = 2;
    public float time = 0;
    public float finalTime;

    public GameObject marcos;

    // Start is called before the first frame update
    void Start()
    {
        marcos.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        coolDown();

        if(time >= finalTime)
        {
            Movimiento();
            marcos.SetActive(true);
        }
    }

    private void Movimiento()
    {
        if(transform.position.x >= -.2f && gameObject.tag == "Izq")
        {
            transform.position = new Vector3(-0.2f, 4.39f, 0);
        }
        else if(transform.position.x <= .2f && gameObject.tag == "Der")
        {
            transform.position = new Vector3(.2f, 4.39f, 0);
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }

    void coolDown()
    {
        time = Time.time + cooldown;
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SombraController : MonoBehaviour
{
    public float speed = .3f;
    public float time;
    float cooldown = 2f;
    public float finalTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CoolDown();

        if(time >= finalTime)
        {
            Movimiento();
        }
    }

    void CoolDown()
    {
        time = Time.time + cooldown;
    }

    void Movimiento()
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

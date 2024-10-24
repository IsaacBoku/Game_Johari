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

    public GameObject[] vidas;

    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaMax;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);

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
        speed -= Time.deltaTime;

        if (speed <= 2)
        {
            speed = 2;
        }
    }
}

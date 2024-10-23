using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIntro : MonoBehaviour
{
    public Animator volumeAnimator;

    public float speed = 10;
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
}

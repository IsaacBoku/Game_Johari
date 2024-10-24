using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenas : MonoBehaviour
{
    float cooldown = 2;
    public float time = 0;
    public float finalTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coolDown();

        if (time >= finalTime)
        {
            SceneManager.LoadScene("Hub");
        }
    }

    void coolDown()
    {
        time = Time.time + cooldown;
    }
}

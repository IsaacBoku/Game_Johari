using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioActivator : MonoBehaviour
{
    public string nombreMusica;
    public string nombreSFX;
    public string nombreMusic2 = "MusicaJuego";
    public float time = 0f;
    float cooldown = 2f;
    public float finalTime;

    bool activador = false;
    //130.8

    // Start is called before the first frame update
    void Start()
    {
       /* AudioManager.instance.PlayMusic(nombreMusica);
        AudioManager.instance.PlaySFX(nombreSFX);*/
    }

    // Update is called once per frame
    void Update()
    {
        CoolDown();

        if(time >= finalTime && activador == false)
        {
            AudioManager.instance.PlaySFX(nombreMusic2);
            activador = true;
        }
    }

    void CoolDown()
    {
        time = Time.time + cooldown;
    }
}

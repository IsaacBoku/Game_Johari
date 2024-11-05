using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sistema_Cameras : MonoBehaviour
{
    [Header("Cameras")]
    public GameObject cameraInicial;
    public GameObject cameraOuticial;

    private void OnTriggerStay2D(Collider2D collision)
    {
        cameraInicial.SetActive(false);
        cameraOuticial.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        cameraInicial.SetActive(true);
        cameraOuticial.SetActive(false);
    }
}

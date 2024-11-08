using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TP_Lobby : MonoBehaviour
{
    public void VolverHUB()
    {
        SceneManager.LoadScene("Hub");
        Time.timeScale = 1.0f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TP_Lobby : MonoBehaviour
{

    public string SceneLoad;
    public void VolverHUB()
    {
        if (!string.IsNullOrEmpty(SceneLoad))
        {
            SceneManager.LoadScene(SceneLoad);
        }
        else 
        {
            Debug.LogError("These is not scene");        
        }
        Time.timeScale = 1.0f;
    }
}

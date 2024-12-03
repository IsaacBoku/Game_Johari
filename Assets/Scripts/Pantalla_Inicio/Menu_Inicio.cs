using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Inicio : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
    }
    public void Start_Game()
    {
        SceneManager.LoadScene("Introcuccion_Cinematic");
        Debug.Log("Has iniciado la partida");
        
    }
    public void Quit_Game()
    {
        Application.Quit();
        Debug.Log("Has salido del juego");
    }
}

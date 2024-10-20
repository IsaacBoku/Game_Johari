using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Inicio : MonoBehaviour
{
    public void Start_Game()
    {
        SceneManager.LoadScene("Inicio");
        Debug.Log("Has iniciado la partida");
    }
    public void Quit_Game()
    {
        Application.Quit();
        Debug.Log("Has salido del juego");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Pausa : MonoBehaviour
{
    [Header("Menus")]
    public GameObject menuPausa;
    public GameObject menuOptions;
    public GameObject menuPrincipal;

    [Header("Menu Options")]
    public GameObject menuVideo;
    public GameObject menuAudio;
    public GameObject menuController;


    public bool isPause = false;


    private void Start()
    {
        isPause = false;
        menuPausa.SetActive(false);
        Time.timeScale = 1.0f;
    }
    private void Update()
    {
        AbrirMenuPausa();
    }
    #region Menu Pausa
    //Sirve cuando le das al Escape se abra el menu de pausa principal, lo que ocurre es que puedas cerrar con el mismo boton usando bool(isPause)
    public void AbrirMenuPausa()
    {
        if ( isPause == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                menuPausa.SetActive(true);
                isPause = true;
                Debug.Log("Open menu Pause");
            }
        }
        else if(isPause == true) 
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                menuPrincipal.SetActive(true);
                menuOptions.SetActive(false);
                menuPausa.SetActive(false );
                Time.timeScale = 1;
                isPause = false;
                Debug.Log("Closed menu pause");
            }
        }
    }
    //Este void sirve para salir del videojuego
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Closed Application");
    }
    //Este void sirve para cerrar el menu de pausa mediante botones
    public void Cerrar_Menu_Pausa()
    {
        Time.timeScale = 1;
        menuPausa.SetActive(false);
        menuOptions.SetActive(false);
        isPause = false;
        Debug.Log("Close menu pause");
    }
    #endregion
    #region Menu Options
    //Este void sirve para abrir el menu de Options mediante botones
    public void Menu_Options()
    {
        menuOptions.SetActive(true);
        menuPrincipal.SetActive(false);
        Debug.Log("Open Options");
    }
    //Este void sirve para abrir el menu de Video mediante botones
    public void Menu_Video()
    {
        menuOptions.SetActive(false);
        menuVideo.SetActive(true);
        Debug.Log("Open Video");
    }
    //Este void sirve para volver al menu principal de pausa
    public void BackMenu()
    {
        menuOptions.SetActive(false);
        menuPrincipal.SetActive(true);
        Debug.Log("Back Menu Pause");
    }
    #endregion

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Pausa : MonoBehaviour
{
    [Header("Menus")]
    public GameObject menuPausa;
    public GameObject menuOptions;
    public GameObject menuPrincipal;


    public bool isPause = false;

    private void Update()
    {
        AbrirMenuPausa();
    }
    public void AbrirMenuPausa()
    {
        if ( isPause == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                menuPausa.SetActive(true);
                isPause = true;
            }
        }
        else if(isPause == true) 
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1;
                menuPausa.SetActive(false);
                isPause = false;
            }
        }

    }
    public void Menu_Options()
    {
        menuOptions.SetActive(true);
        menuPrincipal.SetActive(false);
    }
    public void BackMenu()
    {
        menuOptions.SetActive(false );
        menuPrincipal.SetActive(true);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Animation_Pass : MonoBehaviour
{
    [SerializeField] private GameObject[] vinetas;
    private int indiceActual = 0;

    public bool isSkip = false; 

    private void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            
            Skip_Vineta();
        }
    }
    public void SkipBool()
    {
        isSkip = true;
    }

    public void Skip_Vineta()
    {
        if(isSkip == true)
        {

        Debug.Log("boton de frame");
        if (vinetas.Length > 0)
        {
            vinetas[indiceActual].SetActive(false);
            indiceActual++;
            if(indiceActual >= vinetas.Length)
            {
                SceneManager.LoadScene("Hub");
                indiceActual = 0;
            }
            else
            {

            Debug.Log("Cambie de frame");
            vinetas[indiceActual].SetActive(true);
                    isSkip = false;
            }


        }
        }

    }

}

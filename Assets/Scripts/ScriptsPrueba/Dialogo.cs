using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogo : MonoBehaviour
{
    public Animator dialogAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialogAnim.SetTrigger("Open");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogAnim.SetTrigger("Close");
    }
}

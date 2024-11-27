using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventos_Movimientos_NPC : MonoBehaviour
{
    public Vector3[] waypoints;
    public Vector3[] waypoints2;
    [SerializeField] private Transform NPC;
    [SerializeField] private float duration;

    public bool event1 = true;
    public bool event2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.Space) && event1 == true)
        {

            Move_NPC_Event2();


        }*/
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Move_NPC_Event2();
    }

    void Move_NPC_Event2()
    {
        switch(event1)
        {
            case true:
                NPC.DOPath(waypoints, duration);
                event1 = false;
                event2 = true;
                break;
                case false:
                
                break;

        }
    }
}

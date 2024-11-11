using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguimiento_NPC : MonoBehaviour
{
    [Header("NPC persigue")]
    [SerializeField] public GameObject player;

    [Header("Movement NPC")]
    Vector2 NPCPos;

    bool persiP;
    [SerializeField] public float speed;

    private void Update()
    {
        if (persiP) 
        {
            transform.position = Vector2.MoveTowards(transform.position,NPCPos, speed * Time.deltaTime);
        }
        if(Vector2.Distance(transform.position, NPCPos)>12)
            persiP = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        NPCPos = player.transform.position;
        persiP=true;
    }
}

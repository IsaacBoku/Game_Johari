using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguimiento_NPC : MonoBehaviour
{
    [Header("NPC persigue")]
    [SerializeField] public GameObject player;
    public Rigidbody2D rb;

    [Header("Movement NPC")]
    Vector2 NPCPos;

    bool persiP;
    [SerializeField] public float speed;
    public int facingDir = 1;
    public bool facingRight = true;


    [Header("Tutoriales")]
    [SerializeField] private Transform spaceCheck;
    [SerializeField] private float spaceDistance;
    [SerializeField] protected LayerMask whatIsSpace;



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

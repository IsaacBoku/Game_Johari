using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Timeline_NPC_Introduccion : MonoBehaviour
{
    PlayableDirector directo;
    public Collider2D panelDirecto;


    private void Start()
    {
        directo = GetComponent<PlayableDirector>();
    }
    void StartTimeline()
    {
        directo.Play();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartTimeline();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        panelDirecto.enabled = false;
    }
}

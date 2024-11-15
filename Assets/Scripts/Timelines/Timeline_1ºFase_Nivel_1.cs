using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Timeline_1ºFase_Nivel_1 : MonoBehaviour
{
    [Header("NPC Timeline")]
    [SerializeField] private GameObject _TimelineIntroduccion;

    [Header("Director Timeline")]
    [SerializeField] private PlayableDirector _Director;
    [SerializeField] private Collider2D _trigger2D;


    private void Start()
    {
         _Director = GetComponent<PlayableDirector>();

    }
    private void StartTimeline()
    {
        _Director.Play();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void DialogoNPC()
    {

    }
}

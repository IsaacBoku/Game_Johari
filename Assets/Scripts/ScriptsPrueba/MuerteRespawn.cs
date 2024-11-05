using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteRespawn : MonoBehaviour
{
    public Transform checkPoint;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        player.transform.position = checkPoint.position;
    }
}

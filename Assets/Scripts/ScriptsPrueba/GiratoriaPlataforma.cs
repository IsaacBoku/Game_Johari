using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GiratoriaPlataforma : MonoBehaviour
{
    private bool shouldRotate;
    private float platformLength;
    private Transform player;
    private BoxCollider2D platformCollider;
    private float heightCheckDistance = .5f;

    
    [SerializeField] private float rotationSpeed = 20f;
    [SerializeField] private float rotationMax = 30f;

    private void Update()
    {
        if (shouldRotate)
        {


            Vector3 playerRelativePosition = transform.InverseTransformPoint(player.position);
            float rotationSpeedMultiplier = CalculateRotationMultiplier(playerRelativePosition);
            int rotationDirection = playerRelativePosition.x < 0 ? 1 : -1;


            transform.rotation = Quaternion.RotateTowards(
                from: transform.rotation, 
                to: Quaternion.AngleAxis(rotationMax * rotationDirection, Vector3.forward), 
                maxDegreesDelta: Time.deltaTime * rotationSpeed * rotationSpeedMultiplier);
        }
        else if (transform.rotation.eulerAngles.z != 0)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * rotationSpeed);
        }

        
    }

    private float CalculateRotationMultiplier(Vector3 playerRelativePosition)
    {
        int rotationDirection = playerRelativePosition.x < 0 ? 1 : -1;
        float rotationSpeedMultiplier = Mathf.Abs(Mathf.Clamp((playerRelativePosition.x * 2 / platformLength) * rotationDirection, -1, 1));
        return rotationSpeedMultiplier;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            shouldRotate = true;
            player = collision.gameObject.GetComponent<Transform>();
        }
    }

    
}

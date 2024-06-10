using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 spawnpoint;

    private void Start()
    {
        spawnpoint = transform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            transform.position = spawnpoint;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpawnPoint"))
        {
            spawnpoint = other.transform.position;
        }
    }

    private void Update()
    {
        if (transform.position.y < -2)
        {
            transform.position = spawnpoint;
        }
    }
}

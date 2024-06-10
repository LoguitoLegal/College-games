using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("RotApple"))
        {
            gameManager.LoseHealth();
        }
        Destroy(other.gameObject);
    }
}

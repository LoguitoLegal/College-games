using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int enemyHealth;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float moveSpeed;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && gameObject.tag != "Factory")
        {
            gameManager.RefreshStatus();
            Destroy(gameObject);
        }

        if (other.tag == "PlayerProjectile")
        {
            this.enemyHealth--;

            if (enemyHealth <= 0) {

                Destroy(gameObject);
            }

            Destroy(other.gameObject);
        }
    }

    private void OnDestroy()
    {
        if (gameObject.tag == "Factory")
        {
            gameManager.AddElimination();
            gameManager.RefreshStatus();
        }
    }

    public float GetSpeed()
    {
        return this.moveSpeed;
    }

    public int GetHealth()
    {
        return this.enemyHealth;
    }
}

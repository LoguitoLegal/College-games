using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private float posX;
    [SerializeField] GameManager gameManager;

    void Update()
    {
        posX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(posX, 0f, 0f);

        if (transform.position.x >= 19.5f)
        {
            transform.position = new Vector3(19.5f, -14f, 0f);
        }
        else if (transform.position.x <= -19.5f)
        {
            transform.position = new Vector3(-19.5f, -14f, 0f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Apple"))
        {
            gameManager.EarnPoint();
        }
        else if (other.CompareTag("RotApple"))
        {
            gameManager.LoseHealth();
        }
        else if (other.CompareTag("GoldenApple"))
        {
            gameManager.EarnTwoPoints();
        }
        Destroy(other.gameObject);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraseProjectile : MonoBehaviour
{
    private Renderer bulletRenderer;
    void Start()
    {
        bulletRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        //if (!bulletRenderer.isVisible)
        //{
        //    Destroy(gameObject, 1.5f);
        //}
        if (transform.position.z >= 125 || transform.position.z <= -125) {
            Destroy(gameObject);
        }
        if (transform.position.x >= 125 || transform.position.x <= -125)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerProjectile" && gameObject.tag != "EnemyProjectile")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Factory")
        {
            Destroy(gameObject);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMove : MonoBehaviour
{
    public float speed;

    void Update()
    {

        transform.Translate(Vector3.right * Time.deltaTime * speed);

    }
    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            speed *= -1;
        }

    }

}

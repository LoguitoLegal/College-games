using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;

    public float rotateSpeed = 150f;
    void Update()
    {
        float z = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float y = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;

        transform.Translate(0f, 0f, z);
        transform.Rotate(0f, y, 0f);

    }
}
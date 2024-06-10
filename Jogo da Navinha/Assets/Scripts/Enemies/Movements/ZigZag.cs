using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZag : MonoBehaviour
{
    public float speed = 5f;
    public Vector3 direcao;
    public float invertPosition;
    public Transform cameratransform;
    public bool inverteu = false;

    void Start()
    {
        cameratransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        ZigZagMove();
    }

    public void ZigZagMove()
    {
        transform.Translate(direcao * speed * Time.deltaTime);

        if (inverteu == false)
        {
            if (transform.position.z < (cameratransform.position.z + invertPosition))
            {
                inverteu = true;
                transform.localEulerAngles = new Vector3(0, 0, 0);
            }
        }

    }
}

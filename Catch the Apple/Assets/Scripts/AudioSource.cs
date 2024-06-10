using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourcer : MonoBehaviour
{
    public AudioSource src;

    private void Start()
    {
        src.Play();
    }
}

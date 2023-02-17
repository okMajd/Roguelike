using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioPlay : MonoBehaviour
{
    public AudioSource sfx;
    private void OnEnable()
    {
        sfx.Play();
    }
}

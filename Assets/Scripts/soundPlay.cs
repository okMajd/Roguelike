using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundPlay : MonoBehaviour
{
    public AudioSource sfx;
    private void OnEnable()
    {
        sfx.Play();
    }
}

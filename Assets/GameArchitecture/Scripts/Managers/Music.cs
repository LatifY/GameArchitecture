using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Music
{
    public string name;

    public AudioClip clip;

    public float volume = 1f;
    public float pitch = 1f;
    public bool playOnAwake = true;
    public bool loop = true;

    [HideInInspector] public AudioSource source;
}

using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]

//These variables all appear under EACH sound object in Unity Inspector
public class Sound {

    public string name;

    public AudioClip clip;
   
    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}

using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;
	// Use this for initialization
	void Awake () {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
		
	}

    public void Play(string name)
    {
        //Array is available because of "using System"
        //Find(array name, sound that's equal to the sound name in the String parameter)
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        //Array is available because of "using System"
        //Find(array name, sound that's equal to the sound name in the String parameter)
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.Stop();
    }
}

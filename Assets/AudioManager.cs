using UnityEngine.Audio;
using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;    

    public List<Sound> sounds;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (var s in sounds)
        {
            s.sorce = gameObject.AddComponent<AudioSource>();
            s.sorce.clip = s.clip;
            s.sorce.volume = s.volume;
            s.sorce.pitch = s.pitch;
            s.sorce.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("MainTheme");
    }

    public void Play(string name)
    {
        Sound sound = sounds.Find(s => s.name == name);
        if(sound == null) {
            Debug.Log("Sound " + sound.name + " doesn't exist");
            return;
        }
        sound.sorce.Play();
    }
}

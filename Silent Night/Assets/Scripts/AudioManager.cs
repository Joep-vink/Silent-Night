using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] sounds;

    private void Awake()
    {
        instance = this;

        foreach (Sound s in sounds)
        {
            s.source = s.parent.gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.spatialBlend = s.spacialBlend;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (!s.source.isPlaying && s != null)
            s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s.source.isPlaying && s != null)
            s.source.Stop();
    }

    public void StopAllAudio()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i].source.Stop();
            sounds[i].source.volume = 0;

            /*if (sounds[i].name != "JumpScare")
            {
                
            }*/
        }
    }
}

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    public Transform parent;

    [Range(0.1f, 1)]
    public float volume;

    [Range(0.1f, 3)]
    public float pitch;

    [Range(0, 1)]
    public float spacialBlend;

    public bool loop = false;

    [HideInInspector] public AudioSource source;
}

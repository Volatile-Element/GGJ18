using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    GameObject SoundsContainer;

    private void Awake()
    {
        if (!IsMainInstance())
        {
            return;
        }

        SoundsContainer = new GameObject("Sounds Container");
    }

    public void PlaySingleFire(string resourceLocation)
    {
        PlaySound(resourceLocation, false);
    }

    public void PlayLoop(string resourceLocation)
    {
        PlaySound(resourceLocation, true);
    }

    private void PlaySound(string resourcesLocation, bool loop)
    {
        var audioClip = Resources.Load<AudioClip>(resourcesLocation);

        var sound = new GameObject($"Sound: {audioClip.name} - Created At: {Time.realtimeSinceStartup}");
        sound.transform.parent = SoundsContainer.transform.parent;

        var audioSource = sound.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.playOnAwake = true;
        audioSource.loop = loop;

        if (!loop)
        {
            var destroySelf = sound.AddComponent<DestroySelfIn>();
            destroySelf.SecondsToLive = audioClip.length + 0.5f; //A buffer
        }

        audioSource.Play();
    }
}
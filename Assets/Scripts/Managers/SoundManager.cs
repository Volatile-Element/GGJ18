using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public void PlaySingleFireRandom(string resourceFolder, float range)
    {
        var clips = Resources.LoadAll<AudioClip>(resourceFolder);
        var clip = clips.Skip(Random.Range(0, clips.Length - 1)).FirstOrDefault();

        PlaySound(clip, false);
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

        PlaySound(audioClip, loop);
    }

    public void PlaySound(AudioClip clip, bool loop)
    {
        var sound = new GameObject($"Sound: {clip.name} - Created At: {Time.realtimeSinceStartup}");
        sound.transform.parent = SoundsContainer.transform.parent;

        var audioSource = sound.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.playOnAwake = true;
        audioSource.loop = loop;
        audioSource.volume = 0.5f;

        if (!loop)
        {
            var destroySelf = sound.AddComponent<DestroySelfIn>();
            destroySelf.SecondsToLive = clip.length + 0.5f; //A buffer
        }

        audioSource.Play();
    }
}
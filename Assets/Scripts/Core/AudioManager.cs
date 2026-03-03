using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private GameObject _parentPooling;
    private List<AudioSource> _audioSources = new List<AudioSource>();

    public AudioManager(GameObject parent)
    {
        this._parentPooling = parent;
    }

    public void PlaySound(AudioClip clip)
    {
        var audioSource = GetOrCreateAudioSource();
        audioSource.clip = clip;
        audioSource.Play();
    }

    private AudioSource GetOrCreateAudioSource()
    {
        AudioSource audioSource = _audioSources.Where(x => !x.isPlaying).FirstOrDefault();

        if (audioSource == null)
        {
            audioSource = _parentPooling.AddComponent<AudioSource>();
            _audioSources.Add(audioSource);
        }

        return audioSource;
    }


}

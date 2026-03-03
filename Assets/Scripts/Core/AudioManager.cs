using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private GameObject _parentPooling;
    private List<AudioSource> _audioSources = new List<AudioSource>();

    private AudioSource musicSource; //NUEVO

    public AudioManager(GameObject parent)
    {
        this._parentPooling = parent;

        // Crear AudioSource exclusivo para música
        musicSource = parent.AddComponent<AudioSource>();
        musicSource.loop = true;
        musicSource.playOnAwake = false;
    }

    // --- SFX ---
    public void PlaySound(AudioClip clip)
    {
        var audioSource = GetOrCreateAudioSource();
        audioSource.clip = clip;
        audioSource.Play();
    }

    // --- MÚSICA ---
    public void PlayMusic(AudioClip clip)
    {
        if (musicSource.clip == clip && musicSource.isPlaying)
            return; // evita duplicar música

        musicSource.clip = clip;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_MagicBook : MonoBehaviour
{
    //Private Variables
    private AudioSource _audioSource;
    private AudioClip _audioClip_PageFlipping;

    void Start()
    {
        //Grab a reference to the audio source
        _audioSource = GetComponent<AudioSource>();

        //Assign the correct audio clips from the ResourceManagers
        _audioClip_PageFlipping = ResourceManager.Instance.audio_page_flipping;
    }

    public void PlaySFX_PageFlipping()
    {
        //Play Audio
        _audioSource.clip = _audioClip_PageFlipping;
        _audioSource.Play();
    }

    public void StopSFX_PageFlipping()
    {
        _audioSource.Stop();
    }
}

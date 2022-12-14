using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_HatWearing : MonoBehaviour
{
    //Private Variables
    private AudioSource _audioSource;
    private AudioClip _audioClip_PutHat_On;
    private AudioClip _audioClip_PutHat_Off;

    void Start()
    {
        //Grab a reference to the audio source
        _audioSource = GetComponent<AudioSource>();

        //Assign the correct audio clips from the ResourceManagers
        _audioClip_PutHat_On = ResourceManager.Instance.audio_putHat_on;
        _audioClip_PutHat_Off = ResourceManager.Instance.audio_putHat_off;
    }

    public void PlaySFX_PutHat_On()
    {
        //Play Audio
        _audioSource.clip = _audioClip_PutHat_On;
        _audioSource.Play();
    }

    public void PlaySFX_PutHat_Off()
    {
        //Play Audio
        _audioSource.clip = _audioClip_PutHat_Off;
        _audioSource.Play();
    }
}

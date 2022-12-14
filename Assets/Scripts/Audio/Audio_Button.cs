using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Button : MonoBehaviour
{
    //Private Variables
    private AudioSource _audioSource;
    private AudioClip _audioClip_ButtonPress;

    void Start()
    {
        //Grab a reference to the audio source
        _audioSource = GetComponent<AudioSource>();

        //Assign the correct audio clips from the ResourceManagers
        _audioClip_ButtonPress = ResourceManager.Instance.audio_button_press;
    }


    public void PlaySFX_ButtonPress()
    {
        //Play Audio
        _audioSource.clip = _audioClip_ButtonPress;
        _audioSource.Play();
    }
}

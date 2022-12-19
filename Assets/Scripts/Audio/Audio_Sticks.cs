using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Sticks : MonoBehaviour
{
    //Private Variables
    private AudioSource _audioSource;
    private AudioClip _audioClip_StickPickup;
    private AudioClip _audioClip_StickDrop;
    private bool audioImmunity = true;

    void Start()
    {
        //Grab a reference to the audio source
        _audioSource = GetComponent<AudioSource>();

        //Assign the correct audio clips from the ResourceManagers
        _audioClip_StickPickup = ResourceManager.Instance.audio_stick_pickup;
        _audioClip_StickDrop = ResourceManager.Instance.audio_stick_drop;

        //Trigger removal of audio immunity to avoid immediate drop sound on activation
        Invoke("SpawnAudioImmunity", 0.3f);
    }

    public void PlaySFX_StickPickup()
    {
        //Play Audio
        _audioSource.clip = _audioClip_StickPickup;
        _audioSource.Play();
    }

    public void PlaySFX_StickDrop()
    {
        //Play Audio
        _audioSource.clip = _audioClip_StickDrop;
        _audioSource.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain" && audioImmunity == false)
        {
            PlaySFX_StickDrop();
        }
    }

    private void SpawnAudioImmunity()
    {
        audioImmunity = false;
    }
}

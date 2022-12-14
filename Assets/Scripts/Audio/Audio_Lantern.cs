using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Lantern : MonoBehaviour
{
    //Private Variables
    private AudioSource _audioSource;
    private AudioClip _audioClip_LanternPickup;
    private AudioClip _audioClip_LanternDrop;

    void Start()
    {
        //Grab a reference to the audio source
        _audioSource = GetComponent<AudioSource>();

        //Assign the correct audio clips from the ResourceManagers
        _audioClip_LanternPickup = ResourceManager.Instance.audio_lantern_pickup;
        _audioClip_LanternDrop = ResourceManager.Instance.audio_lantern_drop;
    }

    public void PlaySFX_LanternPickup()
    {
        //Play Audio
        _audioSource.clip = _audioClip_LanternPickup;
        _audioSource.Play();
    }

    public void PlaySFX_LanternDrop()
    {
        //Play Audio
        _audioSource.clip = _audioClip_LanternDrop;
        _audioSource.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlaySFX_LanternDrop();

        //if (collision.gameObject.tag == "Terrain")
        //{
        //    PlaySFX_LanternDrop();
        //}
    }
}

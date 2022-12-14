using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Axe : MonoBehaviour
{
    //Private Variables
    private AudioSource _audioSource;
    private AudioClip _audioClip_AxePullout;
    private AudioClip _audioClip_AxeDrop;
    private bool burriedInTree = true;

    void Start()
    {
        //Grab a reference to the audio source
        _audioSource = GetComponent<AudioSource>();

        //Assign the correct audio clips from the ResourceManagers
        _audioClip_AxePullout = ResourceManager.Instance.audio_axe_pullout;
        _audioClip_AxeDrop = ResourceManager.Instance.audio_axe_drop;
    }

    public void PlaySFX_AxePullout()
    {
        //Using a flag to avoid multiple function calls
        if (burriedInTree == true)
        {
            burriedInTree = false;

            //Play Audio
            _audioSource.clip = _audioClip_AxePullout;
            _audioSource.Play();
        }
    }

    public void PlaySFX_AxeDrop()
    {
        //Play Audio
        _audioSource.clip = _audioClip_AxeDrop;
        _audioSource.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            PlaySFX_AxeDrop();
        }
    }
}

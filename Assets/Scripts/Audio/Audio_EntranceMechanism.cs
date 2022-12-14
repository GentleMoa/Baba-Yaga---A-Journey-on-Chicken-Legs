using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_EntranceMechanism : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] private AudioSource audioSource;

    //Private Variables
    private AudioClip _audioClip_EntranceMechanism_Linkage;

    void Start()
    {
        //Assign the correct audio clips from the ResourceManagers
        _audioClip_EntranceMechanism_Linkage = ResourceManager.Instance.audio_enteringMechanism_linkage;
    }

    public void PlaySFX_EntranceMechanism_Linkage()
    {
        //Play Audio
        audioSource.clip = _audioClip_EntranceMechanism_Linkage;
        audioSource.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_TheHouse : MonoBehaviour
{
    //Private Variables
    private AudioClip _audioClip_TheHouse_Sleeping_1;
    private AudioClip _audioClip_TheHouse_Sleeping_2;
    private AudioClip _audioClip_TheHouse_Confused_1;
    private AudioClip _audioClip_TheHouse_Sniffing_1;
    private AudioClip _audioClip_TheHouse_Acknowledgement_1;
    private AudioClip _audioClip_TheHouse_Sigh_1;
    private AudioClip _audioClip_TheHouseShuttersOpenWithCreek;
    private AudioClip _audioClip_TheHouseShuttersOpenWithoutCreek;
    private AudioClip _audioClip_TheHouseShuttersClose;
    private AudioClip _audioClip_TheHouseRopeLadder;

    //Serialized Variables
    [SerializeField] private AudioSource audioSource_House;
    [SerializeField] private AudioSource audioSource_Window_L;
    [SerializeField] private AudioSource audioSource_Window_R;
    [SerializeField] private AudioSource audioSource_RopeLadder;

    void Start()
    {
        //Assign the correct audio clips from the ResourceManagers
        _audioClip_TheHouse_Sleeping_1 = ResourceManager.Instance.audio_house_sleeping_1;
        _audioClip_TheHouse_Sleeping_2 = ResourceManager.Instance.audio_house_sleeping_2;
        _audioClip_TheHouse_Confused_1 = ResourceManager.Instance.audio_house_confused_1;
        _audioClip_TheHouse_Sniffing_1 = ResourceManager.Instance.audio_house_sniffing_1;
        _audioClip_TheHouse_Acknowledgement_1 = ResourceManager.Instance.audio_house_acknowledgement_1;
        _audioClip_TheHouse_Sigh_1 = ResourceManager.Instance.audio_house_sigh_1;
        _audioClip_TheHouseShuttersOpenWithCreek = ResourceManager.Instance.audio_shutters_open_withCreak;
        _audioClip_TheHouseShuttersOpenWithoutCreek = ResourceManager.Instance.audio_shutters_open_withoutCreak;
        _audioClip_TheHouseShuttersClose = ResourceManager.Instance.audio_shutters_close;
        _audioClip_TheHouseRopeLadder = ResourceManager.Instance.audio_rope_ladder;
    }

    public void PlaySFX_TheHouse_Sleeping_1()
    {
        //Play Audio
        audioSource_House.clip = _audioClip_TheHouse_Sleeping_1;
        audioSource_House.Play();
    }
    public void PlaySFX_TheHouse_Sleeping_2()
    {
        //Play Audio
        audioSource_House.clip = _audioClip_TheHouse_Sleeping_2;
        audioSource_House.Play();
    }
    public void PlaySFX_TheHouse_Confused_1()
    {
        //Play Audio
        audioSource_House.clip = _audioClip_TheHouse_Confused_1;
        audioSource_House.Play();
    }
    public void PlaySFX_TheHouse_Sniffing_1()
    {
        //Play Audio
        audioSource_House.clip = _audioClip_TheHouse_Sniffing_1;
        audioSource_House.Play();
    }
    public void PlaySFX_TheHouse_Acknowledgement_1()
    {
        //Play Audio
        audioSource_House.clip = _audioClip_TheHouse_Acknowledgement_1;
        audioSource_House.Play();
    }
    public void PlaySFX_TheHouse_Sigh_1()
    {
        //Play Audio
        audioSource_House.clip = _audioClip_TheHouse_Sigh_1;
        audioSource_House.Play();
    }

    public void PlaySFX_TheHouse_Shutters_Open_With_Creek()
    {
        //Play Audio (left window)
        audioSource_Window_L.clip = _audioClip_TheHouseShuttersOpenWithCreek;
        audioSource_Window_L.Play();

        //Play Audio (right window)
        audioSource_Window_R.clip = _audioClip_TheHouseShuttersOpenWithCreek;
        audioSource_Window_R.Play();
    }

    public void PlaySFX_TheHouse_Shutters_Open_Without_Creek()
    {
        //Play Audio (left window)
        audioSource_Window_L.clip = _audioClip_TheHouseShuttersOpenWithoutCreek;
        audioSource_Window_L.Play();

        //Play Audio (right window)
        audioSource_Window_R.clip = _audioClip_TheHouseShuttersOpenWithoutCreek;
        audioSource_Window_R.Play();
    }

    public void PlaySFX_TheHouse_Shutters_Close()
    {
        //Play Audio (left window)
        audioSource_Window_L.clip = _audioClip_TheHouseShuttersClose;
        audioSource_Window_L.Play();

        //Play Audio (right window)
        audioSource_Window_R.clip = _audioClip_TheHouseShuttersClose;
        audioSource_Window_R.Play();
    }

    public void PlaySFX_TheHouse_Rope_Ladder()
    {
        //Play Audio
        audioSource_RopeLadder.clip = _audioClip_TheHouseRopeLadder;
        audioSource_RopeLadder.Play();
    }
}

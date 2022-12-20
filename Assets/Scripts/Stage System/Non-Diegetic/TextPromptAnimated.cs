using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TextPromptAnimated : MonoBehaviour
{
    //Private Variable
    private Vector3 sizeSmall = new Vector3(0.0001f, 0.0001f, 1.0f);
    private Vector3 sizeBig = new Vector3(0.006f, 0.006f, 1.0f);
    private float duration = 0.25f;
    private AudioSource _audioSource;
    private AudioClip _audioClip_PaperUIOpen;
    private AudioClip _audioClip_PaperUIClose;

    //Public Variables
    public bool advanceTouch;
    [HideInInspector]
    public bool coroutineAnimFinished;

    void Start()
    {
        //Grab reference to the parent's AudioSource
        _audioSource = GetComponentInParent<AudioSource>();

        //Get AudioClips from ResourceManager
        _audioClip_PaperUIOpen = ResourceManager.Instance.audio_paperUI_open;
        _audioClip_PaperUIClose = ResourceManager.Instance.audio_paperUI_close;

        //Start with the small beginning size
        transform.localScale = sizeSmall;

        //Disable UI at Start
        gameObject.SetActive(false);
    }

    public void EnableUI()
    {
        gameObject.SetActive(true);
    }

    public void DisableUI()
    {
        gameObject.SetActive(false);
    }

    public void GrowUISize()
    {
        //Play Audio
        _audioSource.clip = _audioClip_PaperUIOpen;
        _audioSource.Play();

        StartCoroutine(LerpSize(sizeSmall, sizeBig, duration));
    }

    public void ShrinkUISize()
    {
        //Play Audio
        _audioSource.clip = _audioClip_PaperUIClose;
        _audioSource.Play();

        StartCoroutine(LerpSize(sizeBig, sizeSmall, duration));
    }

    IEnumerator LerpSize(Vector3 startSize, Vector3 endSize, float duration)
    {
        float time = 0;

        while (time < duration)
        {
            transform.localScale = Vector3.Lerp(startSize, endSize, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.localScale = endSize;
        coroutineAnimFinished = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        //If either hand of the user is touching this trigger collider and the advancement bool is false yet...
        if (other.gameObject.GetComponent<ActionBasedController>() != null && advanceTouch == false)
        {
            //Set flag after user touches the prompt to progress the stage
            advanceTouch = true;
        }

        //If either hand of the user is touching this trigger collider and this UI Prompt DOES have an Animator Component
        if (other.gameObject.GetComponent<ActionBasedController>() != null && gameObject.GetComponent<Animator>() != null)
        {
            //Play Audio
            _audioSource.clip = _audioClip_PaperUIClose;
            _audioSource.Play();

            //Trigger Hiding animation
            gameObject.GetComponent<Animator>().SetTrigger("UI_Hide");
        }
    }

    public void PlayPaperUIOpenSFX_ViaAnimEvent()
    {
        //Play Audio
        _audioSource.clip = _audioClip_PaperUIOpen;
        _audioSource.Play();
    }
}

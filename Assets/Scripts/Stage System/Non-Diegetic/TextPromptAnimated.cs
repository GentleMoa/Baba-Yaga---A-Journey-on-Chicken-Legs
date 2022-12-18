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

    //Public Variables
    public bool advanceTouch;
    [HideInInspector]
    public bool coroutineAnimFinished;

    void Start()
    {
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
        StartCoroutine(LerpSize(sizeSmall, sizeBig, duration));
    }

    public void ShrinkUISize()
    {
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
            //Trigger Hiding animation
            gameObject.GetComponent<Animator>().SetTrigger("UI_Hide");
        }
    }
}

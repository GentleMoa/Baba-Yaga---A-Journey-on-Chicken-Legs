using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeTransitions : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] private Canvas[] fadeCanvas;

    void Start()
    {
        //If fadeCanvases are not connected in the inspector
        if (fadeCanvas.Length == 0)
        {
            Debug.Log("fadeCanvas are not connected in the inspector!");
        }

        Invoke("StartingFade", 1.5f);
    }

    public void Fade(bool black)
    {
        if (black)
        {
            //Fade to Black
            for (int i = 0; i < fadeCanvas.Length; i++)
            {
                //Enable fadeEffect objects
                EnableFadeEffectObjects();

                //Set Animators bool true
                fadeCanvas[i].GetComponentInChildren<Animator>().SetTrigger("FadeToBlack");
            }
        }
        else
        {
            //Fade from Black
            for (int i = 0; i < fadeCanvas.Length; i++)
            {
                //Set Animators bool true
                fadeCanvas[i].GetComponentInChildren<Animator>().SetTrigger("FadeFromBlack");

                //Disable fadeEffect objects
                Invoke("DisableFadeEffectObjects", 2.1f);
            }
        }
    }

    private void EnableFadeEffectObjects()
    {
        for (int i = 0; i < fadeCanvas.Length; i++)
        {
            //Enable fadeEffect objects
            fadeCanvas[i].gameObject.SetActive(true);
        }
    }

    private void DisableFadeEffectObjects()
    {
        for (int i = 0; i < fadeCanvas.Length; i++)
        {
            //Disable fadeEffect objects
            fadeCanvas[i].gameObject.SetActive(false);
        }
    }

    private void StartingFade()
    {
        for (int i = 0; i < fadeCanvas.Length; i++)
        {
            //Set Animators Trigger
            fadeCanvas[i].GetComponentInChildren<Animator>().SetTrigger("StartingFade");

            //Disable fadeEffect objects
            Invoke("DisableFadeEffectObjects", 2.1f);
        }
    }
}

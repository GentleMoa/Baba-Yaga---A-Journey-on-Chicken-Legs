//Script by Felix Venne, purpose: Script using the input system to toggle "Witch Senses" on XR controller button press
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class WitchSenses : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] private InputActionReference input_primaryButton;
    [SerializeField] private Volume ppVolume;
    [SerializeField] private VolumeProfile default_PPVolume;
    [SerializeField] private VolumeProfile witchSenses_PPVolume;
    [SerializeField] private WitchSenses oppositeHandScript;
    [SerializeField] private AudioSource audioSource;

    //Private Variables
    private bool _primaryButtonCooldown = false;
    private AudioClip _audioClip_WitchSensesOn;
    private AudioClip _audioClip_WitchSensesOff;

    //Public Variables
    [HideInInspector]
    public bool _witchSensesActive = false;

    //Lists
    List<GameObject> highlightedObjects = new List<GameObject>();

    void OnEnable()
    {
        //Subscribe to AudioEvents
        AudioManager.Instance.AE_Player_WitchSenses_On += Play_Audio_WitchSensesOn;
        AudioManager.Instance.AE_Player_WitchSenses_Off += Play_Audio_WitchSensesOff;
    }

    void Start()
    {
        //Get AudioClips from ResourceManager
        _audioClip_WitchSensesOn = ResourceManager.Instance.audio_witchSenses_on;
        _audioClip_WitchSensesOff = ResourceManager.Instance.audio_witchSenses_off;

        //Get all Objects that are interactable / quest related and add them to a list
        foreach (GameObject taggedObjects in GameObject.FindGameObjectsWithTag("HighlightedObject"))
        {
            highlightedObjects.Add(taggedObjects);
        }
    }

    void Update()
    {
        if (input_primaryButton.action.ReadValue<float>() == 0)
        {
            //Resetting the _primaryButtonCooldown
            _primaryButtonCooldown = false;
        }

        //On button press...
        if (input_primaryButton.action.ReadValue<float>() > 0 && _primaryButtonCooldown == false)
        {
            //Checking wether to activate or deactivate Witch Senses
            if (_witchSensesActive == false || oppositeHandScript._witchSensesActive == false)
            {
                //Witch Senses are activated!
                SwitchSenses(witchSenses_PPVolume);

                //Highlight interactive and important objects
                HighlightObjects(true);

                //Setting the _witchSensesActive bool to true
                _witchSensesActive = true;
                oppositeHandScript._witchSensesActive = true;

                //Activate Emissive on all highlightedObjects
                for (int i = 0; i < highlightedObjects.Count; i++)
                {
                    if (highlightedObjects[i].GetComponent<Renderer>() != null)
                    {
                        highlightedObjects[i].GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                    }
                }

                //Play Audio
                AudioManager.Instance.ShootAudioEvent_Player_WitchSenses_On();

                Debug.Log("Witch Senses are activated!");
            }
            else if (_witchSensesActive == true)
            {
                //Witch Senses are deactivated!
                SwitchSenses(default_PPVolume);

                //Un-highlight interactive and important objects
                HighlightObjects(false);

                //Setting the _witchSensesActive bool to false
                _witchSensesActive = false;
                oppositeHandScript._witchSensesActive = false;

                //Deactivate Emissive on all highlightedObjects
                for (int i = 0; i < highlightedObjects.Count; i++)
                {
                    if (highlightedObjects[i].GetComponent<Renderer>() != null)
                    {
                        highlightedObjects[i].GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
                    }
                }

                //Play Audio
                AudioManager.Instance.ShootAudioEvent_Player_WitchSenses_Off();

                Debug.Log("Witch Senses are deactivated!");
            }

            //Debugging
            //Debug.Log("The primary button has been pressed!");

            //Activating the _primaryButtonCooldown
            _primaryButtonCooldown = true;
        }
    }

    void SwitchSenses(VolumeProfile profileToSwitchTo)
    {
        //Lerp weight from 1 to 0, Paramenters: float lerpDuration, float startValue, float endValue
        StartCoroutine(LerpPPVolumeWeight(1.0f, 1.0f, 0.3f));

        //Switch Profiles
        ppVolume.profile = profileToSwitchTo;

        //Lerp weight from 0 to 1, Paramenters: float lerpDuration, float startValue, float endValue
        StartCoroutine(LerpPPVolumeWeight(1.0f, 0.0f, 1.0f));
    }

    IEnumerator LerpPPVolumeWeight(float lerpDuration, float startValue, float endValue)
    {
        float timeElapsed = 0.0f;
        while (timeElapsed < lerpDuration)
        {
            ppVolume.weight = Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        ppVolume.weight = endValue;
    }

    void HighlightObjects(bool highlight)
    {
        //Add all interactive and important objects to a array/list (via layers) --> could also be done in start
        //Make sure all are setup with a red emmissive color but have emmissive unchecked
        //Activate/deactivate emmissive based on highlight bool
    }

    private void Play_Audio_WitchSensesOn()
    {
        audioSource.clip = _audioClip_WitchSensesOn;
        audioSource.Play();
    }

    private void Play_Audio_WitchSensesOff()
    {
        audioSource.clip = _audioClip_WitchSensesOff;
        audioSource.Play();
    }

    void OnDisable()
    {
        //Unsubscribe from AudioEvents
        AudioManager.Instance.AE_Player_WitchSenses_On -= Play_Audio_WitchSensesOn;
        AudioManager.Instance.AE_Player_WitchSenses_Off -= Play_Audio_WitchSensesOff;
    }
}

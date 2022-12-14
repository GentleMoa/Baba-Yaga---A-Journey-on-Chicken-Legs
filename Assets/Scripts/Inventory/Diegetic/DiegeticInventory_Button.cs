using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiegeticInventory_Button : MonoBehaviour
{
    //Private Variables
    private Vector3 _buttonDefaultPosition;
    private AudioSource _audioSource;
    private AudioClip _audioClip_HatInventoryOpen;
    private AudioClip _audioClip_HatInventoryClose;

    //Serialized Variables
    [SerializeField] private Animator ringMenuAnimator;
    [SerializeField] private Transform buttonDefaultTransform;
    [SerializeField] private GameObject[] slots;
    [SerializeField] private Material emissiveMat;

    //Public Variables
    public bool inventoryOpen;

    void Start()
    {
        //Grab a reference to the audio source
        _audioSource = GetComponent<AudioSource>();

        //Assign the correct audio clips from the ResourceManagers
        _audioClip_HatInventoryOpen = ResourceManager.Instance.audio_hat_inventory_open;
        _audioClip_HatInventoryClose = ResourceManager.Instance.audio_hat_inventory_close;
    }

    public void TriggerDIAnim()
    {
        if (inventoryOpen == false)
        {
            //Trigger Animation DI_Open
            ringMenuAnimator.SetTrigger("DI_Open");

            //Enable Trigger Colliders with a delay of 1 sec
            StartCoroutine(ToggleTriggerColliders(1.5f, true, true));

            //Play Audio
            _audioSource.clip = _audioClip_HatInventoryOpen;
            _audioSource.Play();
        }
        else if (inventoryOpen == true)
        {
            //Trigger Animation DI_Close
            ringMenuAnimator.SetTrigger("DI_Close");

            //Disable Trigger Colliders with a delay of 1 sec
            StartCoroutine(ToggleTriggerColliders(0.1f, false, false));

            //Play Audio
            _audioSource.clip = _audioClip_HatInventoryClose;
            _audioSource.Play();
        }
    }

    private void Update()
    {
        //Setting the default button pos to the buttonDefaultTransform.position
        _buttonDefaultPosition = buttonDefaultTransform.position;
    }


    public void ResetButtonPosition()
    {
        //Resetting the transforms to the original values
        this.gameObject.transform.position = _buttonDefaultPosition;
    }

    public void ExplicitlyCloseInventory()
    {
        if (inventoryOpen == true)
        {
            //Trigger Animation DI_Close
            ringMenuAnimator.SetTrigger("DI_Close");

            //Play Audio
            _audioSource.clip = _audioClip_HatInventoryClose;
            _audioSource.Play();

            //Set inventoryOpen Flag
            inventoryOpen = false;
        }
    }

    private IEnumerator ToggleTriggerColliders(float waitSeconds, bool enable, bool inventoryFlag)
    {
        yield return new WaitForSeconds(waitSeconds);

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].GetComponent<Collider>().enabled = enable;
        }

        //Set inventoryOpen Flag
        inventoryOpen = inventoryFlag;
    }

    public void RefreshEmissiveMat()
    {
        bool refreshed = false;

        if (refreshed == false)
        {
            refreshed = true;

            GetComponent<Renderer>().material = emissiveMat;
        }
    }
}

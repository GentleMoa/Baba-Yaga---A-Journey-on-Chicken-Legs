using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ItemRetriever : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] private DiegeticInventory_Button diButtonScript;

    //Private Variables
    private bool _itemRetrieved;
    private RingMenuSlot _ringMenuSlot;
    private Vector3 _defaultSize;
    private Vector3 _hoverSize = new Vector3(110.0f, 110.0f, 110.0f);
    private AudioSource _audioSource;
    private AudioClip _audioClip_HatInventoryRetrieve;

    void Start()
    {
        //Get all slot scripts into the array
        _ringMenuSlot = this.gameObject.GetComponent<RingMenuSlot>();

        //Save the default Size
        _defaultSize = transform.localScale;

        //Grab a reference to the audio source
        _audioSource = GetComponent<AudioSource>();

        //Assign the correct audio clips from the ResourceManagers
        _audioClip_HatInventoryRetrieve = ResourceManager.Instance.audio_hat_inventory_retrieve;
    }

    private void OnTriggerStay(Collider other)
    {
        //Check if the object is one of the hands/controllers
        if (other.gameObject.GetComponent<ActionBasedController>() != null)
        {
            //if grab button press
            if (other.gameObject.GetComponent<ActionBasedController>().selectAction.action.ReadValue<float>() > 0 && 
                /* other.gameObject.GetComponent<HandOccupationChecker>().handFull == false && */ _itemRetrieved == false && 
                diButtonScript.inventoryOpen == true)

            {
                if (_ringMenuSlot.stashedItems.Count > 0)
                {
                    //Reposition item from RingMenuSlot Script's stashedItems List
                    _ringMenuSlot.stashedItems[0].transform.position = this.gameObject.transform.position + new Vector3(0.0f, 0.15f, 0.0f);

                    //Set Rigidbody velocity to 0
                    _ringMenuSlot.stashedItems[0].GetComponent<Rigidbody>().velocity = new Vector3 (0.0f, 0.0f, 0.0f);

                    //Activate item from RingMenuSlot Script's stashedItems List
                    _ringMenuSlot.stashedItems[0].SetActive(true);

                    //Remove it from the List
                    _ringMenuSlot.stashedItems.Remove(_ringMenuSlot.stashedItems[0]);

                    //Update Quantity Display
                    _ringMenuSlot.UpdateItemQuantityDisplay();

                    //Set Flag (Prevents all stashedItems of a type from being retrieved at once)
                    _itemRetrieved = true;

                    //Reset Flag after a delay
                    Invoke("ResetRetrievedFlag", 1.0f);

                    //Play Audio
                    _audioSource.clip = _audioClip_HatInventoryRetrieve;
                    _audioSource.Play();
                }
            }

            //Debug.Log("Hand Hovered over Slot!");
        }
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ActionBasedController>() != null)
        {
            StartCoroutine(LerpSize(_defaultSize, _hoverSize, 0.1f));
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<ActionBasedController>() != null)
        {
            StartCoroutine(LerpSize(_hoverSize, _defaultSize, 1.1f));
        }
    }


    private void ResetRetrievedFlag()
    {
        //Reset Flag
        _itemRetrieved = false;
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
    }
}

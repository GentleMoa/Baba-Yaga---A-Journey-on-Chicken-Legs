using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ND_I_ItemRetriever : MonoBehaviour
{
    //Private Variables
    private bool _itemRetrieved;
    private ND_I_ItemSlots _itemSlotScript;
    private Vector3 _defaultSize;
    private Vector3 _hoverSize = new Vector3(1.25f, 1.25f, 1.0f);
    private ND_Highlighting _highlightingHand_L;
    private ND_Highlighting _highlightingHand_R;

    void Start()
    {
        //Grab reference to the ND_I_ItemSlots Script on this same object
        _itemSlotScript = GetComponent<ND_I_ItemSlots>();

        //Save the default Size
        _defaultSize = transform.localScale;

        //Find Reference to both ND_Highlighting scripts (Right & Left Hands)
        _highlightingHand_L = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<ND_Highlighting>();
        _highlightingHand_R = GameObject.FindGameObjectWithTag("RightHand").GetComponent<ND_Highlighting>();
    }

    private void OnTriggerStay(Collider other)
    {
        //Check if the object is one of the hands/controllers
        if (other.gameObject.GetComponent<ActionBasedController>() != null)
        {
            //if grab button press
            if (other.gameObject.GetComponent<ActionBasedController>().selectAction.action.ReadValue<float>() > 0 &&
                other.gameObject.GetComponent<ND_Inventory_Accessor>()._inventoryOpen == true &&
                _itemRetrieved == false)

            {
                if (_itemSlotScript.stashedItems.Count > 0)
                {
                    //Reposition item from RingMenuSlot Script's stashedItems List
                    _itemSlotScript.stashedItems[0].transform.position = this.gameObject.transform.position;

                    //Set Rigidbody velocity to 0
                    _itemSlotScript.stashedItems[0].GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);

                    //Add object to the highlighted objects list
                    _highlightingHand_L.highlightedObjects.Add(_itemSlotScript.stashedItems[0]);
                    _highlightingHand_R.highlightedObjects.Add(_itemSlotScript.stashedItems[0]);

                    //Activate item from RingMenuSlot Script's stashedItems List
                    _itemSlotScript.stashedItems[0].SetActive(true);

                    //Remove it from the List
                    _itemSlotScript.stashedItems.Remove(_itemSlotScript.stashedItems[0]);

                    //Update Quantity Display
                    _itemSlotScript.UpdateItemQuantityDisplay();

                    //Set Flag (Prevents all stashedItems of a type from being retrieved at once)
                    _itemRetrieved = true;

                    //Reset Flag after a delay
                    Invoke("ResetRetrievedFlag", 1.0f);

                    //Play Audio
                    //_audioSource.clip = _audioClip_HatInventoryRetrieve;
                    //_audioSource.Play();
                }
            }
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
            StartCoroutine(LerpSize(_hoverSize, _defaultSize, 0.1f));
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

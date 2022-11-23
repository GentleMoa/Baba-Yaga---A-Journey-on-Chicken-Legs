using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketItemFakeSwap : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] private GameObject wrappedBandages;

    //Private Variables
    private GameObject _defaultBandages;
    private WitchSenses _witchSenses_R;
    private WitchSenses _witchSenses_L;

    void Start()
    {
        //Disable WrappedBandages in the beginning
        wrappedBandages.SetActive(false);

        //Find Reference to both WitchSenses script (Right & Left Hands)
        _witchSenses_R = GameObject.FindGameObjectWithTag("RightHand").GetComponent<WitchSenses>();
        _witchSenses_L = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<WitchSenses>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ItemController>() != null)
        {
            if (other.gameObject.GetComponent<ItemController>().Item.itemName == "Bandages")
            {
                if (_defaultBandages == null)
                {
                    _defaultBandages = other.gameObject;
                }
            }
        }
    }

    public void SwapBandages()
    {
        //Remove _defaultBandages from WitchSenses highlightedObjects List
        _witchSenses_R.highlightedObjects.Remove(_defaultBandages);
        _witchSenses_L.highlightedObjects.Remove(_defaultBandages);

        Destroy(_defaultBandages);
        wrappedBandages.SetActive(true);
    }
}

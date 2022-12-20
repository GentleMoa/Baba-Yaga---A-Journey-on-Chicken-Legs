using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ND_SocketItemFakeSwap : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] private GameObject wrappedBandages;

    //Private Variables
    private GameObject _defaultBandages;
    private ND_Highlighting _highlightingScript_L;
    private ND_Highlighting _highlightingScript_R;

    void Start()
    {
        //Disable WrappedBandages in the beginning
        wrappedBandages.SetActive(false);

        //Find Reference to both ND_Highlighting scripts (Right & Left Hands)
        _highlightingScript_L = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<ND_Highlighting>();
        _highlightingScript_R = GameObject.FindGameObjectWithTag("RightHand").GetComponent<ND_Highlighting>();
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
        //Remove _defaultBandages from highlightedObjects list
        _highlightingScript_L.highlightedObjects.Remove(_defaultBandages);
        _highlightingScript_R.highlightedObjects.Remove(_defaultBandages);

        Destroy(_defaultBandages);
        wrappedBandages.SetActive(true);
    }
}

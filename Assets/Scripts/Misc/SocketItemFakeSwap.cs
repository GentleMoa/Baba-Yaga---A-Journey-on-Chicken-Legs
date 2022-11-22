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

    void Start()
    {
        wrappedBandages.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "TO_TreeBandages_Item")
        {
            if (_defaultBandages == null)
            {
                _defaultBandages = other.gameObject;
            }
        }
    }

    public void SwapBandages()
    {
        Destroy(_defaultBandages);
        wrappedBandages.SetActive(true);
    }
}

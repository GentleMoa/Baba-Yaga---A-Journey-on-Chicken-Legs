using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchHatUnparenter : MonoBehaviour
{
    //Private Variables
    private bool _parented = true;

    public void UnparentWitchHat()
    {
        if (_parented)
        {
            _parented = false;

            gameObject.transform.parent = null;
        }
    }
}

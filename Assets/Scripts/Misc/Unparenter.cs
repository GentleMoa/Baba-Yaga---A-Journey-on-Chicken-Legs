using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unparenter : MonoBehaviour
{
    //Private Variables
    private bool _parented = true;

    public void Unparent()
    {
        if (_parented)
        {
            _parented = false;

            gameObject.transform.parent = null;
        }
    }
}

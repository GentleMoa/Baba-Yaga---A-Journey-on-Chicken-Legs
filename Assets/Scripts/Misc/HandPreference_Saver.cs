using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPreference_Saver : MonoBehaviour
{
    //Public Variables
    public bool currentHand_right = true;
    public bool grabbed = false;

    public void ToggleGrabbedBool(bool boolean)
    {
        grabbed = boolean;
    }
}

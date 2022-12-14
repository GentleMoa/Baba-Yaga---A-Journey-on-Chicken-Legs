using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandPreference_Adapter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //If touched object has HandPreference_Saver Component...
        if (other.gameObject.GetComponent<HandPreference_Saver>() != null)
        {
            //Check if this is the right or left controller/hand
            if (gameObject.tag == "RightHand")
            {
                //Check if the interactables currentHand is opposite to the one hovering it, while the object is not being grabbed by another hand ...
                if (other.gameObject.GetComponent<HandPreference_Saver>().currentHand_right == false && other.gameObject.GetComponent<HandPreference_Saver>().grabbed == false)
                {
                    //Swap the flag to indicate that the new currentHand is matching with the hand hovering it
                    other.gameObject.GetComponent<HandPreference_Saver>().currentHand_right = true;
                    //Rotate interactable attachPoint to match the right handed orientation
                    other.gameObject.transform.Find("AttachPoint").transform.Rotate(0.0f, -180.0f, 0.0f, Space.Self);
                }
            }
            else if (gameObject.tag == "LeftHand")
            {
                //Check if the interactables currentHand is opposite to the one hovering it, while the object is not being grabbed by another hand ...
                if (other.gameObject.GetComponent<HandPreference_Saver>().currentHand_right == true && other.gameObject.GetComponent<HandPreference_Saver>().grabbed == false)
                {
                    //Swap the flag to indicate that the new currentHand is matching with the hand hovering it
                    other.gameObject.GetComponent<HandPreference_Saver>().currentHand_right = false;
                    //Rotate interactable attachPoint to match the right handed orientation
                    other.gameObject.transform.Find("AttachPoint").transform.Rotate(0.0f, +180.0f, 0.0f, Space.Self);
                }
            }
        }
    }
}

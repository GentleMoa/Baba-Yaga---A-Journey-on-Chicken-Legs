using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingMenuSlot : MonoBehaviour
{
    //Defining the Enum
    public enum HandledItem
    {
        Borage,
        WoolPlant,
        Bandages,
        Seed,
        Stick,
        Totem
    }

    //Public Variables
    public HandledItem handledItem;
    public List<GameObject> stashedItems = new List<GameObject>();

    //Serialized Variables
    [SerializeField] private GameObject[] numbers3D;

    private void Start()
    {
        //Disabling all 3D Numbers except "0" at Start
        for (int i = 1; i < numbers3D.Length; i++)
        {
            numbers3D[i].SetActive(false);
        }
    }

    public void UpdateItemQuantityDisplay()
    {
        //Disable all 3D Numbers aka. clearing the slate
        for (int i = 0; i < numbers3D.Length; i++)
        {
            numbers3D[i].SetActive(false);
        }

        //Enabling the 3D Number fitting the amount of stashed Items
        numbers3D[stashedItems.Count].SetActive(true);
    }

}

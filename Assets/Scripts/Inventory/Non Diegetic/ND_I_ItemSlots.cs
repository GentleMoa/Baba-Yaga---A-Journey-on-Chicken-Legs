using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_I_ItemSlots : MonoBehaviour
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
    [SerializeField] private GameObject[] numbersND;

    void Start()
    {
        //Disabling all Non-Diegetic Numbers except "0" at Start
        for (int i = 1; i < numbersND.Length; i++)
        {
            numbersND[i].SetActive(false);
        }
    }

    public void UpdateItemQuantityDisplay()
    {
        //Disable all Non-Diegetic Numbers aka. clearing the slate
        for (int i = 0; i < numbersND.Length; i++)
        {
            numbersND[i].SetActive(false);
        }

        //Enabling the Non-Diegetic Number fitting the amount of stashed Items
        numbersND[stashedItems.Count].SetActive(true);
    }
}

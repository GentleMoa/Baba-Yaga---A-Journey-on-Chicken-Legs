using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCraftedItemsToHighlightList : MonoBehaviour
{
    //Private Variables
    private WitchSenses _witchSenses_R;
    private WitchSenses _witchSenses_L;

    void Start()
    {
        //Find Reference to both WitchSenses script (Right & Left Hands)
        _witchSenses_R = GameObject.FindGameObjectWithTag("RightHand").GetComponent<WitchSenses>();
        _witchSenses_L = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<WitchSenses>();

        //Add this freshly crafted Item to the list of highlighted objects
        if (_witchSenses_R != null && _witchSenses_L != null)
        {
            _witchSenses_R.highlightedObjects.Add(this.gameObject);
            _witchSenses_L.highlightedObjects.Add(this.gameObject);
        }
    }
}

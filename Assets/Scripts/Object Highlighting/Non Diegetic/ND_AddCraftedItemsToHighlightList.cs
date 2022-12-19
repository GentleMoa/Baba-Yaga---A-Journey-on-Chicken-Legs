using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_AddCraftedItemsToHighlightList : MonoBehaviour
{
    //Private Variables
    private ND_Highlighting _highlightingHand_L;
    private ND_Highlighting _highlightingHand_R;

    void Start()
    {
        //Find Reference to both ND_Highlighting scripts (Right & Left Hands)
        _highlightingHand_L = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<ND_Highlighting>();
        _highlightingHand_R = GameObject.FindGameObjectWithTag("RightHand").GetComponent<ND_Highlighting>();

        //Add this freshly crafted Item to the list of highlighted objects
        if (_highlightingHand_R != null && _highlightingHand_L != null)
        {
            _highlightingHand_R.highlightedObjects.Add(this.gameObject);
            _highlightingHand_L.highlightedObjects.Add(this.gameObject);

            //If highlighting is currently active...
            if (_highlightingHand_L._highlightingActive || _highlightingHand_R._highlightingActive)
            {
                //Disable highlighting effect for tree
                gameObject.GetComponentInChildren<ND_UI_Highlighter>(true).EnableHighlightingUI();
                gameObject.GetComponentInChildren<ND_UI_Highlighter>(true).GrowUISize();
            }
        }
    }
}

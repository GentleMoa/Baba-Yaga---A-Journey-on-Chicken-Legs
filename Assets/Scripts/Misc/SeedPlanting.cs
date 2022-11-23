using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedPlanting : MonoBehaviour
{
    //Public Variables
    public bool plantingActivated;
    private WitchSenses _witchSenses_R;
    private WitchSenses _witchSenses_L;

    //Serialized Variables
    [SerializeField] private Stage_2_4 stage_2_4;
    [SerializeField] GameObject[] magicPlants;

    private void OnCollisionEnter(Collision collision)
    {
        if (plantingActivated == true)
        {
            if (collision.gameObject.tag == "Terrain")
            {
                //Up counter by 1
                stage_2_4.plantedSeeds += 1;

                //Spawn Magic Plant
                Instantiate(magicPlants[stage_2_4.plantedSeeds - 1], this.transform.position, Quaternion.identity * Quaternion.Euler(-90.0f, 0.0f, 0.0f));

                //Remove Seed from highlighted Objects List
                _witchSenses_R.highlightedObjects.Remove(this.gameObject);
                _witchSenses_L.highlightedObjects.Remove(this.gameObject);

                //Disable Emission effect for Hatchet
                this.gameObject.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");

                //Destroy Seed
                Destroy(this.gameObject);
            }
        }
    }

    private void Start()
    {
        //Find Reference to both WitchSenses script (Right & Left Hands)
        _witchSenses_R = GameObject.FindGameObjectWithTag("RightHand").GetComponent<WitchSenses>();
        _witchSenses_L = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<WitchSenses>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_SeedPlanting : MonoBehaviour
{
    //Public Variables
    public bool plantingActivated;
    private ND_Highlighting _highlightingScript_L;
    private ND_Highlighting _highlightingScript_R;

    //Serialized Variables
    [SerializeField] private ND_Stage_2_3 ND_stage_2_3;
    [SerializeField] private ND_Stage_2_4 ND_stage_2_4;
    [SerializeField] GameObject[] magicPlants;

    //Private Variables
    private AudioSource _audioSource;
    private AudioClip _audioClip_SeedPlanting;

    private void Start()
    {
        //Find Reference to both ND_Highlighting scripts (Right & Left Hands)
        _highlightingScript_L = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<ND_Highlighting>();
        _highlightingScript_R = GameObject.FindGameObjectWithTag("RightHand").GetComponent<ND_Highlighting>();

        //Grab a reference to the audio source
        _audioSource = GetComponent<AudioSource>();

        //Assign the correct audio clips from the ResourceManagers
        _audioClip_SeedPlanting = ResourceManager.Instance.audio_seed_planting;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (plantingActivated == true)
        {
            if (collision.gameObject.tag == "Terrain")
            {
                //Bool to prohibit multiple effect calls
                plantingActivated = false;

                //Up stage_2_3's "plantedSeeds" counter by 1
                ND_stage_2_3.plantedSeeds += 1;

                //Up stage_2_4's "plantedSeeds" counter by 1
                ND_stage_2_4.plantedSeeds += 1;

                //Spawn Magic Plant
                Instantiate(magicPlants[ND_stage_2_4.plantedSeeds - 1], this.transform.position, Quaternion.identity * Quaternion.Euler(-90.0f, 0.0f, 0.0f));

                //Remove Seed from highlighted Objects List
                _highlightingScript_L.highlightedObjects.Remove(gameObject);
                _highlightingScript_R.highlightedObjects.Remove(gameObject);

                ////If highlighting is currently active...
                //if (_highlightingScript_L._highlightingActive || _highlightingScript_R._highlightingActive)
                //{
                //    //Disable highlighting effect for hatchet
                //    gameObject.GetComponentInChildren<ND_UI_Highlighter>(true).ShrinkUISize();
                //    gameObject.GetComponentInChildren<ND_UI_Highlighter>(true).Invoke("DisableHighlightingUI", 0.3f);
                //}

                //Play Audio
                _audioSource.clip = _audioClip_SeedPlanting;
                _audioSource.Play();

                //Disable mesh renderer to make the seed disappear
                GetComponent<MeshRenderer>().enabled = false;

                //Delayed destruction of seed so the audio clip playback can finish first
                Invoke("DestroySeed", 1.5f);
            }
        }
    }

    private void DestroySeed()
    {
        //Destroy Seed
        Destroy(this.gameObject);
    }
}

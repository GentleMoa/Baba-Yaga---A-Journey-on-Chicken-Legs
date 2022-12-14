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
    [SerializeField] private Stage_2_3 stage_2_3;
    [SerializeField] private Stage_2_4 stage_2_4;
    [SerializeField] GameObject[] magicPlants;

    //Private Variables
    private AudioSource _audioSource;
    private AudioClip _audioClip_SeedPlanting;

    private void Start()
    {
        //Find Reference to both WitchSenses script (Right & Left Hands)
        _witchSenses_R = GameObject.FindGameObjectWithTag("RightHand").GetComponent<WitchSenses>();
        _witchSenses_L = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<WitchSenses>();

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
                stage_2_3.plantedSeeds += 1;

                //Up stage_2_4's "plantedSeeds" counter by 1
                stage_2_4.plantedSeeds += 1;

                //Spawn Magic Plant
                Instantiate(magicPlants[stage_2_4.plantedSeeds - 1], this.transform.position, Quaternion.identity * Quaternion.Euler(-90.0f, 0.0f, 0.0f));

                //Remove Seed from highlighted Objects List
                _witchSenses_R.highlightedObjects.Remove(this.gameObject);
                _witchSenses_L.highlightedObjects.Remove(this.gameObject);

                //Disable Emission effect for Seed
                this.gameObject.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");

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

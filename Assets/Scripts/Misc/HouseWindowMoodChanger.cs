using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseWindowMoodChanger : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] private GameObject[] windows;
    [SerializeField] private Light searchLight;
    [SerializeField] private Material mat_emissive_G;
    [SerializeField] private Material mat_emissive_Y;
    [SerializeField] private Material mat_emissive_R;

    //Private
    private bool _searchLightTracking;
    private GameObject _searchLightParent;
    private Transform _player;

    void Start()
    {
        _searchLightParent = searchLight.gameObject.transform.parent.gameObject;
        _player = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Camera>().gameObject.transform;
    }

    void Update()
    {
        //Tracking condition
        if (_searchLightTracking)
        {
            //Searchlight LookAt Player
            _searchLightParent.transform.LookAt(_player);
        }
    }

    public void SwitchToMat_G()
    {
        for (int i = 0; i < windows.Length; i++)
        {
            //Approach 1 didn't work (This: windows[i].GetComponent<Renderer>().materials[1] = wantedMaterial;)
            //Copy the material list to a temporary variables
            var tempMatList = windows[i].GetComponent<Renderer>().materials;
            //Assign the wanted material to the correct index of the temporary mat list
            tempMatList[1] = mat_emissive_G;

            //Assign the new temp material list to the used mat list of the object
            windows[i].GetComponent<Renderer>().materials = tempMatList;
        }

        //Also change color of searchlight (to green)
        searchLight.color = new Color32(0, 191, 4, 1);
    }

    public void SwitchToMat_Y()
    {
        for (int i = 0; i < windows.Length; i++)
        {
            //Approach 1 didn't work (This: windows[i].GetComponent<Renderer>().materials[1] = wantedMaterial;)
            //Copy the material list to a temporary variables
            var tempMatList = windows[i].GetComponent<Renderer>().materials;
            //Assign the wanted material to the correct index of the temporary mat list
            tempMatList[1] = mat_emissive_Y;

            //Assign the new temp material list to the used mat list of the object
            windows[i].GetComponent<Renderer>().materials = tempMatList;
        }

        //Also change color of searchlight (to yellow)
        searchLight.color = new Color32(191, 137, 0, 1);
    }

    public void SwitchToMat_R()
    {
        for (int i = 0; i < windows.Length; i++)
        {
            //Approach 1 didn't work (This: windows[i].GetComponent<Renderer>().materials[1] = wantedMaterial;)
            //Copy the material list to a temporary variables
            var tempMatList = windows[i].GetComponent<Renderer>().materials;
            //Assign the wanted material to the correct index of the temporary mat list
            tempMatList[1] = mat_emissive_R;

            //Assign the new temp material list to the used mat list of the object
            windows[i].GetComponent<Renderer>().materials = tempMatList;
        }

        //Also change color of searchlight (to red)
        searchLight.color = new Color32(191, 0, 0, 1);
    }

    public void ToggleSearchLightLookAt(int binaryBool)
    {
        if (binaryBool == 0)
        {
            //Set Flag
            _searchLightTracking = false;

            //Reset Searchlight Rotation
            _searchLightParent.SetActive(false);
        }
        else if (binaryBool == 1)
        {
            //Enable Searchlight
            _searchLightParent.SetActive(true);

            //Set Flag
            _searchLightTracking = true;
        }
    }

    public void EnableSearchLight()
    {
        //Enable Searchlight
        _searchLightParent.SetActive(true);
    }
}

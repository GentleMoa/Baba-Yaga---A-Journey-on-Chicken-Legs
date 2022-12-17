using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ND_UI_Highlighter : MonoBehaviour
{
    //Private Variable
    private GameObject _playerCam;
    private Vector3 sizeSmall = new Vector3(0.0001f, 0.0001f, 1.0f);
    private Vector3 sizeBig = new Vector3(0.0125f, 0.0125f, 1.0f);
    private float duration = 0.25f;

    void Start()
    {
        //Start with the small beginning size
        transform.localScale = sizeSmall;

        //Find _playerCam by tag
        _playerCam = GameObject.FindGameObjectWithTag("MainCamera");

        //Disable UI at Start
        gameObject.SetActive(false);
    }

    void Update()
    {
        //Force the object to look at the player camera
        transform.LookAt(_playerCam.transform);
        //Save current rotation as Vector 3
        Vector3 _currentRotation = transform.rotation.eulerAngles;
        //Zero-out the axis that should stay static
        transform.rotation = Quaternion.Euler(0.0f, _currentRotation.y, 0.0f);
    }

    public void EnableHighlightingUI()
    {
        gameObject.SetActive(true);
        //gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void DisableHighlightingUI()
    {
        gameObject.SetActive(false);
        //gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void GrowUISize()
    {
        StartCoroutine(LerpSize(sizeSmall, sizeBig, duration));
    }

    public void ShrinkUISize()
    {
        StartCoroutine(LerpSize(sizeBig, sizeSmall, duration));
    }

    IEnumerator LerpSize(Vector3 startSize, Vector3 endSize, float duration)
    {
        float time = 0;

        while (time < duration)
        {
            transform.localScale = Vector3.Lerp(startSize, endSize, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.localScale = endSize;
    }
}

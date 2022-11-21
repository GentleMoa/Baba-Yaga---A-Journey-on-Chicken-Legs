//ResourceManager holding most of the resources/assets used during runtime to avoid cluttering of the other scripts
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    //Singleton
    public static ResourceManager Instance { set; get; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    //Resources

    [Header("Audio")]

    [Header("Witch Senses")]
    public AudioClip audio_witchSenses_on;
    public AudioClip audio_witchSenses_off;

    [Header("Prefabs")]

    [Header("Crafted Items")]
    public GameObject bandages;
    public GameObject[] witchTotems;
}

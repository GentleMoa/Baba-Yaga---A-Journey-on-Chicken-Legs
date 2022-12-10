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
    [Header("Prefabs")]

    [Header("Crafted Items")]
    public GameObject bandages;
    public GameObject[] witchTotems;

    [Header("Audio")]

    [Header("Witch Senses")]
    public AudioClip audio_witchSenses_on;
    public AudioClip audio_witchSenses_off;

    [Header("Trapdoor Action")]
    public AudioClip audio_trapdoor_open;
    public AudioClip audio_trapdoor_close;

    [Header("Ladder Climbing")]
    public AudioClip audio_ladder_climbing;

    [Header("Owl Voice Lines")]
    [Header("Tutorial")]
    public AudioClip owl_VL_T_1_1;
    public AudioClip owl_VL_T_1_2;
    public AudioClip owl_VL_T_1_3;
    public AudioClip owl_VL_T_2_1;
    public AudioClip owl_VL_T_2_2;
    public AudioClip owl_VL_T_2_3;
    public AudioClip owl_VL_T_2_4;
    public AudioClip owl_VL_T_3_1;
    public AudioClip owl_VL_T_3_2;
    public AudioClip owl_VL_T_4_1;
    public AudioClip owl_VL_T_4_2;
    public AudioClip owl_VL_T_5_1;
    public AudioClip owl_VL_T_5_2;
    public AudioClip owl_VL_T_5_3;
    public AudioClip owl_VL_T_5_4;
    public AudioClip owl_VL_T_6_1;
    public AudioClip owl_VL_T_6_2;
    public AudioClip owl_VL_T_6_3;
    public AudioClip owl_VL_T_6_4;
    public AudioClip owl_VL_T_6_5;

    [Header("Task 1")]
    public AudioClip owl_VL_1_1;
    public AudioClip owl_VL_1_2;
    public AudioClip owl_VL_1_3;
    public AudioClip owl_VL_1_4;
    public AudioClip owl_VL_1_5;
    public AudioClip owl_VL_1_6;
    public AudioClip owl_VL_1_7;
    public AudioClip owl_VL_1_8;
    public AudioClip owl_VL_1_9;

    [Header("Task 2")]
    public AudioClip owl_VL_2_1;
    public AudioClip owl_VL_2_2;
    public AudioClip owl_VL_2_3;
    public AudioClip owl_VL_2_4;
    public AudioClip owl_VL_2_5;

    [Header("Task 3")]
    public AudioClip owl_VL_3_1;
    public AudioClip owl_VL_3_2;
    public AudioClip owl_VL_3_3;
    public AudioClip owl_VL_3_4;
    public AudioClip owl_VL_3_5;
    public AudioClip owl_VL_3_6;

    [Header("Ending")]
    public AudioClip owl_VL_Ending;
}

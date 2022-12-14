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

    [Header("Lantern Pickup / Drop")]
    public AudioClip audio_lantern_pickup;
    public AudioClip audio_lantern_drop;

    [Header("Teleport Magic")]
    public AudioClip audio_teleport_magic;

    [Header("Page Flipping")]
    public AudioClip audio_page_flipping;

    [Header("Cauldron Boiling")]
    public AudioClip audio_cauldron_boiling;

    [Header("Button Press")]
    public AudioClip audio_button_press;

    [Header("Entering Mechanism Linkage")]
    public AudioClip audio_enteringMechanism_linkage;

    [Header("Axe Sounds")]
    public AudioClip audio_axe_pullout;
    public AudioClip audio_axe_drop;

    [Header("Plant Pickup")]
    public AudioClip audio_plant_pickup;

    [Header("Magic Inventory")]
    public AudioClip audio_hat_inventory_open;
    public AudioClip audio_hat_inventory_close;
    public AudioClip audio_hat_inventory_stash;
    public AudioClip audio_hat_inventory_retrieve;
    public AudioClip audio_putHat_on;
    public AudioClip audio_putHat_off;

    [Header("Crafting")]
    public AudioClip audio_crafting_bandages;
    public AudioClip audio_crafting_totems;

    [Header("Bandage Wrapping")]
    public AudioClip audio_bandage_wrapping;

    [Header("Seed Planting")]
    public AudioClip audio_seed_planting;
    public AudioClip audio_plant_growing;

    [Header("Sticks Pickup / Drop")]
    public AudioClip audio_stick_pickup;
    public AudioClip audio_stick_drop;

    [Header("Totem Hanging")]
    public AudioClip audio_totem_hanging;

    [Header("TheHouse Vocalisation")]
    public AudioClip audio_house_sleeping_1;
    public AudioClip audio_house_sleeping_2;
    public AudioClip audio_house_confused_1;
    public AudioClip audio_house_sniffing_1;
    public AudioClip audio_house_acknowledgement_1;
    public AudioClip audio_house_sigh_1;

    [Header("TheHouse Shutters")]
    public AudioClip audio_shutters_open_withCreak;
    public AudioClip audio_shutters_open_withoutCreak;
    public AudioClip audio_shutters_close;

    [Header("TheHouse Rope Ladder")]
    public AudioClip audio_rope_ladder;

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

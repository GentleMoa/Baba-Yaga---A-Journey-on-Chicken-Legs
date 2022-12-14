//AudioManager to provide a ordered workflow for audio triggering during runtime
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    #region AudioEvents

    //Audio Events
    //Audio Events named by this convention: "AudioEvent" + "Audio Source Gameobject" + "Audio Specification"
    //For example: "AE_Player_WitchSenses_On" ---> "AE" (marking it as Audio Event), "Player" (the gameobject which will play the sound), "WitchSenses_On" (the specific sound that will be played)
    //Witch Senses
    public event Action AE_Player_WitchSenses_On;
    public event Action AE_Player_WitchSenses_Off;

    //Trapdoor Action
    public event Action AE_Trapdoor_Open;
    public event Action AE_Trapdoor_Close;

    //Ladder Climbing
    public event Action AE_Ladder_Climbing;

    //Lantern Pickup / Drop
    public event Action AE_Lantern_Pickup;
    public event Action AE_Lantern_Drop;

    //Teleport Magic
    public event Action AE_Teleport_Magic;

    //Page Flipping
    public event Action AE_Page_Flipping;

    //Cauldron Boiling
    public event Action AE_Cauldron_Boiling;

    //Button Press
    public event Action AE_Button_Press;

    //Entrance Mechanism Linkage
    public event Action AE_EntranceMechanism_Linkage;

    //Axe Sounds
    public event Action AE_Axe_Pullout;
    public event Action AE_Axe_Drop;

    //Plant Pickup
    public event Action AE_Plant_Pickup;

    //Magic Inventory
    public event Action AE_Hat_Inventory_Open;
    public event Action AE_Hat_Inventory_Close;
    public event Action AE_Hat_Inventory_Stash;
    public event Action AE_Hat_Inventory_Retrieve;
    public event Action AE_PutHat_On;
    public event Action AE_PutHat_Off;

    //Crafting
    public event Action AE_Crafting_Bandages;
    public event Action AE_Crafting_Totems;

    //Bandage Wrapping
    public event Action AE_Bandage_Wrapping;

    //Seed Planting
    public event Action AE_Seed_Planting;
    public event Action AE_Plant_Growing;

    //Stick Pickup / Drop
    public event Action AE_Stick_Pickup;
    public event Action AE_Stick_Drop;

    //Totem Hanging
    public event Action AE_Totem_Hanging;

    //The House Vocalisation
    public event Action AE_TheHouse_Vocalisation;

    //The House Shutters
    public event Action AE_TheHouse_Shutters_Open;
    public event Action AE_TheHouse_Shutters_Close;

    //The House Shutters
    public event Action AE_TheHouse_Rope_Ladder;

    //Owl Companion Voice Lines
    public event Action AE_Owl_VL_T_1_1;
    public event Action AE_Owl_VL_T_1_2;
    public event Action AE_Owl_VL_T_1_3;
    public event Action AE_Owl_VL_T_2_1;
    public event Action AE_Owl_VL_T_2_2;
    public event Action AE_Owl_VL_T_2_3;
    public event Action AE_Owl_VL_T_2_4;
    public event Action AE_Owl_VL_T_3_1;
    public event Action AE_Owl_VL_T_3_2;
    public event Action AE_Owl_VL_T_4_1;
    public event Action AE_Owl_VL_T_4_2;
    public event Action AE_Owl_VL_T_5_1;
    public event Action AE_Owl_VL_T_5_2;
    public event Action AE_Owl_VL_T_5_3;
    public event Action AE_Owl_VL_T_5_4;
    public event Action AE_Owl_VL_T_6_1;
    public event Action AE_Owl_VL_T_6_2;
    public event Action AE_Owl_VL_T_6_3;
    public event Action AE_Owl_VL_T_6_4;
    public event Action AE_Owl_VL_T_6_5;

    public event Action AE_Owl_VL_1_1;
    public event Action AE_Owl_VL_1_2;
    public event Action AE_Owl_VL_1_3;
    public event Action AE_Owl_VL_1_4;
    public event Action AE_Owl_VL_1_5;
    public event Action AE_Owl_VL_1_6;
    public event Action AE_Owl_VL_1_7;
    public event Action AE_Owl_VL_1_8;
    public event Action AE_Owl_VL_1_9;

    public event Action AE_Owl_VL_2_1;
    public event Action AE_Owl_VL_2_2;
    public event Action AE_Owl_VL_2_3;
    public event Action AE_Owl_VL_2_4;
    public event Action AE_Owl_VL_2_5;

    public event Action AE_Owl_VL_3_1;
    public event Action AE_Owl_VL_3_2;
    public event Action AE_Owl_VL_3_3;
    public event Action AE_Owl_VL_3_4;
    public event Action AE_Owl_VL_3_5;
    public event Action AE_Owl_VL_3_6;

    public event Action AE_Owl_VL_Ending;

    #endregion

    //Singleton
    public static AudioManager Instance { set; get; }

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

    #region Audio Events Activation

    //Audio Events Activation
    //Witch Senses
    public void ShootAudioEvent_Player_WitchSenses_On()
    {
        AE_Player_WitchSenses_On();
    }

    public void ShootAudioEvent_Player_WitchSenses_Off()
    {
        AE_Player_WitchSenses_Off();
    }

    //Trapdoor Actions
    public void ShootAudioEvent_Trapdoor_Open()
    {
        AE_Trapdoor_Open();
    }

    public void ShootAudioEvent_Trapdoor_Close()
    {
        AE_Trapdoor_Close();
    }

    //Ladder Climbing
    public void ShootAudioEvent_Ladder_Climbing()
    {
        AE_Ladder_Climbing();
    }

    //Lantern Pickup
    public void ShootAudioEvent_Lantern_Pickup()
    {
        AE_Lantern_Pickup();
    }

    //Lantern Drop
    public void ShootAudioEvent_Lantern_Drop()
    {
        AE_Lantern_Drop();
    }

    //Teleport Magic
    public void ShootAudioEvent_Teleport_Magic()
    {
        AE_Teleport_Magic();
    }

    //Page Flipping
    public void ShootAudioEvent_Page_Flipping()
    {
        AE_Page_Flipping();
    }

    //Cauldron Boiling
    public void ShootAudioEvent_Cauldron_Boiling()
    {
        AE_Cauldron_Boiling();
    }

    //Button Press
    public void ShootAudioEvent_Button_Press()
    {
        AE_Button_Press();
    }

    //Axe Pullout
    public void ShootAudioEvent_Axe_Pullout()
    {
        AE_Axe_Pullout();
    }

    //Axe Drop
    public void ShootAudioEvent_Axe_Drop()
    {
        AE_Axe_Drop();
    }

    //Plant Pickup
    public void ShootAudioEvent_Plant_Pickup()
    {
        AE_Plant_Pickup();
    }

    //Hat Inventory Open
    public void ShootAudioEvent_Hat_Inventory_Open()
    {
        AE_Hat_Inventory_Open();
    }

    //Hat Inventory Close
    public void ShootAudioEvent_Hat_Inventory_Close()
    {
        AE_Hat_Inventory_Close();
    }

    //Hat Inventory Stash
    public void ShootAudioEvent_Hat_Inventory_Stash()
    {
        AE_Hat_Inventory_Stash();
    }

    //Hat Inventory Retrieve
    public void ShootAudioEvent_Hat_Inventory_Retrieve()
    {
        AE_Hat_Inventory_Retrieve();
    }

    //Crafting Bandages
    public void ShootAudioEvent_Crafting_Bandages()
    {
        AE_Crafting_Bandages();
    }

    //Crafting Totems
    public void ShootAudioEvent_Crafting_Totems()
    {
        AE_Crafting_Totems();
    }

    //Bandage Wrapping
    public void ShootAudioEvent_Bandage_Wrapping()
    {
        AE_Bandage_Wrapping();
    }

    //Seed Planting
    public void ShootAudioEvent_Seed_Planting()
    {
        AE_Seed_Planting();
    }

    //Plant Growing
    public void ShootAudioEvent_Plant_Growing()
    {
        AE_Plant_Growing();
    }

    //Stick Pickup
    public void ShootAudioEvent_Stick_Pickup()
    {
        AE_Stick_Pickup();
    }

    //Plant Drop
    public void ShootAudioEvent_Stick_Drop()
    {
        AE_Stick_Drop();
    }

    //Totem Hanging
    public void ShootAudioEvent_Totem_Hanging()
    {
        AE_Totem_Hanging();
    }

    //The House Vocalisation
    public void ShootAudioEvent_TheHouse_Vocalisation()
    {
        AE_TheHouse_Vocalisation();
    }

    //TheHouse Shutters Open
    public void ShootAudioEvent_TheHouse_Shutters_Open()
    {
        AE_TheHouse_Shutters_Open();
    }

    //TheHouse Shutters Close
    public void ShootAudioEvent_TheHouse_Shutters_Close()
    {
        AE_TheHouse_Shutters_Close();
    }

    //TheHouse Rope Ladder
    public void ShootAudioEvent_TheHouse_Rope_Ladder()
    {
        AE_TheHouse_Rope_Ladder();
    }

    //Owl Companion Voice Lines
    public void ShootAudioEvent_Owl_VL_T_1_1()
    {
        if (AE_Owl_VL_T_1_1 != null)
        {
            AE_Owl_VL_T_1_1();
        }
    }
    public void ShootAudioEvent_Owl_VL_T_1_2()
    {
        AE_Owl_VL_T_1_2();
    }
    public void ShootAudioEvent_Owl_VL_T_1_3()
    {
        AE_Owl_VL_T_1_3();
    }
    public void ShootAudioEvent_Owl_VL_T_2_1()
    {
        AE_Owl_VL_T_2_1();
    }
    public void ShootAudioEvent_Owl_VL_T_2_2()
    {
        AE_Owl_VL_T_2_2();
    }
    public void ShootAudioEvent_Owl_VL_T_2_3()
    {
        AE_Owl_VL_T_2_3();
    }
    public void ShootAudioEvent_Owl_VL_T_2_4()
    {
        AE_Owl_VL_T_2_4();
    }
    public void ShootAudioEvent_Owl_VL_T_3_1()
    {
        AE_Owl_VL_T_3_1();
    }
    public void ShootAudioEvent_Owl_VL_T_3_2()
    {
        AE_Owl_VL_T_3_2();
    }
    public void ShootAudioEvent_Owl_VL_T_4_1()
    {
        AE_Owl_VL_T_4_1();
    }
    public void ShootAudioEvent_Owl_VL_T_4_2()
    {
        AE_Owl_VL_T_4_2();
    }
    public void ShootAudioEvent_Owl_VL_T_5_1()
    {
        AE_Owl_VL_T_5_1();
    }
    public void ShootAudioEvent_Owl_VL_T_5_2()
    {
        AE_Owl_VL_T_5_2();
    }
    public void ShootAudioEvent_Owl_VL_T_5_3()
    {
        AE_Owl_VL_T_5_3();
    }
    public void ShootAudioEvent_Owl_VL_T_5_4()
    {
        if (AE_Owl_VL_T_5_4 != null)
        {
            AE_Owl_VL_T_5_4();
        }
    }
    public void ShootAudioEvent_Owl_VL_T_6_1()
    {
        if (AE_Owl_VL_T_6_1 != null)
        {
            AE_Owl_VL_T_6_1();
        }
    }
    public void ShootAudioEvent_Owl_VL_T_6_2()
    {
        AE_Owl_VL_T_6_2();
    }
    public void ShootAudioEvent_Owl_VL_T_6_3()
    {
        AE_Owl_VL_T_6_3();
    }
    public void ShootAudioEvent_Owl_VL_T_6_4()
    {
        AE_Owl_VL_T_6_4();
    }
    public void ShootAudioEvent_Owl_VL_T_6_5()
    {
        AE_Owl_VL_T_6_5();
    }

    public void ShootAudioEvent_Owl_VL_1_1()
    {
        AE_Owl_VL_1_1();
    }
    public void ShootAudioEvent_Owl_VL_1_2()
    {
        AE_Owl_VL_1_2();
    }
    public void ShootAudioEvent_Owl_VL_1_3()
    {
        AE_Owl_VL_1_3();
    }
    public void ShootAudioEvent_Owl_VL_1_4()
    {
        AE_Owl_VL_1_4();
    }
    public void ShootAudioEvent_Owl_VL_1_5()
    {
        AE_Owl_VL_1_5();
    }
    public void ShootAudioEvent_Owl_VL_1_6()
    {
        AE_Owl_VL_1_6();
    }
    public void ShootAudioEvent_Owl_VL_1_7()
    {
        AE_Owl_VL_1_7();
    }
    public void ShootAudioEvent_Owl_VL_1_8()
    {
        AE_Owl_VL_1_8();
    }
    public void ShootAudioEvent_Owl_VL_1_9()
    {
        AE_Owl_VL_1_9();
    }
    public void ShootAudioEvent_Owl_VL_2_1()
    {
        AE_Owl_VL_2_1();
    }
    public void ShootAudioEvent_Owl_VL_2_2()
    {
        AE_Owl_VL_2_2();
    }
    public void ShootAudioEvent_Owl_VL_2_3()
    {
        AE_Owl_VL_2_3();
    }
    public void ShootAudioEvent_Owl_VL_2_4()
    {
        AE_Owl_VL_2_4();
    }
    public void ShootAudioEvent_Owl_VL_2_5()
    {
        AE_Owl_VL_2_5();
    }
    public void ShootAudioEvent_Owl_VL_3_1()
    {
        AE_Owl_VL_3_1();
    }
    public void ShootAudioEvent_Owl_VL_3_2()
    {
        AE_Owl_VL_3_2();
    }
    public void ShootAudioEvent_Owl_VL_3_3()
    {
        AE_Owl_VL_3_3();
    }
    public void ShootAudioEvent_Owl_VL_3_4()
    {
        AE_Owl_VL_3_4();
    }
    public void ShootAudioEvent_Owl_VL_3_5()
    {
        AE_Owl_VL_3_5();
    }
    public void ShootAudioEvent_Owl_VL_3_6()
    {
        AE_Owl_VL_3_6();
    }
    public void ShootAudioEvent_Owl_VL_Ending()
    {
        AE_Owl_VL_Ending();
    }

    #endregion
}

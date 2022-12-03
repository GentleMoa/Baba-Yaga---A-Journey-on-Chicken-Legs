using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlVerbalCommentary : MonoBehaviour
{
    //Private Variables
    private AudioSource _audioSource;

    //Serialized Variables
    [SerializeField] Stage_T_1_1 stage_T_1_1;
    [SerializeField] Stage_T_5_2 stage_T_5_2;
    [SerializeField] Stage_T_6_1 stage_T_6_1;
    [SerializeField] Stage_T_5_4 stage_T_5_4;

    // Start is called before the first frame update
    void Start()
    {
        //Get component reference
        _audioSource = GetComponent<AudioSource>();

        if (StageManager.Instance.currentStage == stage_T_1_1)
        {
            PlayFirstCommentary();
        }
    }

    private void OnEnable()
    {
        //Call Coroutine to subscribe Audio functions to AudioManager Events
        StartCoroutine(SubscribeToAudioEvents(0.15f));
    }

    IEnumerator SubscribeToAudioEvents(float waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);

        //Subscribe Audio functions to AudioManager Events
        AudioManager.Instance.AE_Owl_VL_T_1_1 += Play_Owl_VL_T_1_1;
        AudioManager.Instance.AE_Owl_VL_T_1_2 += Play_Owl_VL_T_1_2;
        AudioManager.Instance.AE_Owl_VL_T_1_3 += Play_Owl_VL_T_1_3;
        AudioManager.Instance.AE_Owl_VL_T_2_1 += Play_Owl_VL_T_2_1;
        AudioManager.Instance.AE_Owl_VL_T_2_2 += Play_Owl_VL_T_2_2;
        AudioManager.Instance.AE_Owl_VL_T_2_3 += Play_Owl_VL_T_2_3;
        AudioManager.Instance.AE_Owl_VL_T_2_4 += Play_Owl_VL_T_2_4;
        AudioManager.Instance.AE_Owl_VL_T_3_1 += Play_Owl_VL_T_3_1;
        AudioManager.Instance.AE_Owl_VL_T_3_2 += Play_Owl_VL_T_3_2;
        AudioManager.Instance.AE_Owl_VL_T_4_1 += Play_Owl_VL_T_4_1;
        AudioManager.Instance.AE_Owl_VL_T_4_2 += Play_Owl_VL_T_4_2;
        AudioManager.Instance.AE_Owl_VL_T_5_1 += Play_Owl_VL_T_5_1;
        AudioManager.Instance.AE_Owl_VL_T_5_2 += Play_Owl_VL_T_5_2;
        AudioManager.Instance.AE_Owl_VL_T_5_3 += Play_Owl_VL_T_5_3;
        AudioManager.Instance.AE_Owl_VL_T_5_4 += Play_Owl_VL_T_5_4;
        AudioManager.Instance.AE_Owl_VL_T_6_1 += Play_Owl_VL_T_6_1;
        AudioManager.Instance.AE_Owl_VL_T_6_2 += Play_Owl_VL_T_6_2;
        AudioManager.Instance.AE_Owl_VL_T_6_3 += Play_Owl_VL_T_6_3;
        AudioManager.Instance.AE_Owl_VL_T_6_4 += Play_Owl_VL_T_6_4;
        AudioManager.Instance.AE_Owl_VL_T_6_5 += Play_Owl_VL_T_6_5;

        AudioManager.Instance.AE_Owl_VL_1_1 += Play_Owl_VL_1_1;
        AudioManager.Instance.AE_Owl_VL_1_2 += Play_Owl_VL_1_2;
        AudioManager.Instance.AE_Owl_VL_1_3 += Play_Owl_VL_1_3;
        AudioManager.Instance.AE_Owl_VL_1_4 += Play_Owl_VL_1_4;
        AudioManager.Instance.AE_Owl_VL_1_5 += Play_Owl_VL_1_5;
        AudioManager.Instance.AE_Owl_VL_1_6 += Play_Owl_VL_1_6;
        AudioManager.Instance.AE_Owl_VL_1_7 += Play_Owl_VL_1_7;
        AudioManager.Instance.AE_Owl_VL_1_8 += Play_Owl_VL_1_8;
        AudioManager.Instance.AE_Owl_VL_1_9 += Play_Owl_VL_1_9;

        AudioManager.Instance.AE_Owl_VL_2_1 += Play_Owl_VL_2_1;
        AudioManager.Instance.AE_Owl_VL_2_2 += Play_Owl_VL_2_2;
        AudioManager.Instance.AE_Owl_VL_2_3 += Play_Owl_VL_2_3;
        AudioManager.Instance.AE_Owl_VL_2_4 += Play_Owl_VL_2_4;
        AudioManager.Instance.AE_Owl_VL_2_5 += Play_Owl_VL_2_5;

        AudioManager.Instance.AE_Owl_VL_3_1 += Play_Owl_VL_3_1;
        AudioManager.Instance.AE_Owl_VL_3_2 += Play_Owl_VL_3_2;
        AudioManager.Instance.AE_Owl_VL_3_3 += Play_Owl_VL_3_3;
        AudioManager.Instance.AE_Owl_VL_3_4 += Play_Owl_VL_3_4;
        AudioManager.Instance.AE_Owl_VL_3_5 += Play_Owl_VL_3_5;
        AudioManager.Instance.AE_Owl_VL_3_6 += Play_Owl_VL_3_6;

        AudioManager.Instance.AE_Owl_VL_Ending += Play_Owl_VL_Ending;
    }

    private void OnDisable()
    {
        //Unsubscribe Audio functions from AudioManager Events
        AudioManager.Instance.AE_Owl_VL_T_1_1 -= Play_Owl_VL_T_1_1;
        AudioManager.Instance.AE_Owl_VL_T_1_2 -= Play_Owl_VL_T_1_2;
        AudioManager.Instance.AE_Owl_VL_T_1_3 -= Play_Owl_VL_T_1_3;
        AudioManager.Instance.AE_Owl_VL_T_2_1 -= Play_Owl_VL_T_2_1;
        AudioManager.Instance.AE_Owl_VL_T_2_2 -= Play_Owl_VL_T_2_2;
        AudioManager.Instance.AE_Owl_VL_T_2_3 -= Play_Owl_VL_T_2_3;
        AudioManager.Instance.AE_Owl_VL_T_2_4 -= Play_Owl_VL_T_2_4;
        AudioManager.Instance.AE_Owl_VL_T_3_1 -= Play_Owl_VL_T_3_1;
        AudioManager.Instance.AE_Owl_VL_T_3_2 -= Play_Owl_VL_T_3_2;
        AudioManager.Instance.AE_Owl_VL_T_4_1 -= Play_Owl_VL_T_4_1;
        AudioManager.Instance.AE_Owl_VL_T_4_2 -= Play_Owl_VL_T_4_2;
        AudioManager.Instance.AE_Owl_VL_T_5_1 -= Play_Owl_VL_T_5_1;
        AudioManager.Instance.AE_Owl_VL_T_5_2 -= Play_Owl_VL_T_5_2;
        AudioManager.Instance.AE_Owl_VL_T_5_3 -= Play_Owl_VL_T_5_3;
        AudioManager.Instance.AE_Owl_VL_T_5_4 -= Play_Owl_VL_T_5_4;
        AudioManager.Instance.AE_Owl_VL_T_6_1 -= Play_Owl_VL_T_6_1;
        AudioManager.Instance.AE_Owl_VL_T_6_2 -= Play_Owl_VL_T_6_2;
        AudioManager.Instance.AE_Owl_VL_T_6_3 -= Play_Owl_VL_T_6_3;
        AudioManager.Instance.AE_Owl_VL_T_6_4 -= Play_Owl_VL_T_6_4;
        AudioManager.Instance.AE_Owl_VL_T_6_5 -= Play_Owl_VL_T_6_5;
    }

    #region Play Audio Functions

    private void Play_Owl_VL_T_1_1()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_T_1_1;
        _audioSource.Play();
    }
    private void Play_Owl_VL_T_1_2()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_T_1_2;
        _audioSource.Play();
    }
    private void Play_Owl_VL_T_1_3()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_T_1_3;
        _audioSource.Play();
    }
    private void Play_Owl_VL_T_2_1()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_T_2_1;
        _audioSource.Play();
    }
    private void Play_Owl_VL_T_2_2()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_T_2_2;
        _audioSource.Play();
    }
    private void Play_Owl_VL_T_2_3()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_T_2_3;
        _audioSource.Play();
    }
    private void Play_Owl_VL_T_2_4()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_T_2_4;
        _audioSource.Play();
    }
    private void Play_Owl_VL_T_3_1()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_T_3_1;
        _audioSource.Play();
    }
    private void Play_Owl_VL_T_3_2()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_T_3_2;
        _audioSource.Play();
    }
    private void Play_Owl_VL_T_4_1()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_T_4_1;
        _audioSource.Play();
    }
    private void Play_Owl_VL_T_4_2()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_T_4_2;
        _audioSource.Play();
    }
    private void Play_Owl_VL_T_5_1()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_T_5_1;
        _audioSource.Play();
    }
    private void Play_Owl_VL_T_5_2()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_T_5_2;
        _audioSource.Play();
    }
    private void Play_Owl_VL_T_5_3()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_T_5_3;
        _audioSource.Play();
    }
    private void Play_Owl_VL_T_5_4()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_T_5_4;
        _audioSource.Play();
    }
    private void Play_Owl_VL_T_6_1()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_T_6_1;
        _audioSource.Play();
    }
    private void Play_Owl_VL_T_6_2()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_T_6_2;
        _audioSource.Play();
    }
    private void Play_Owl_VL_T_6_3()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_T_6_3;
        _audioSource.Play();
    }
    private void Play_Owl_VL_T_6_4()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_T_6_4;
        _audioSource.Play();
    }
    private void Play_Owl_VL_T_6_5()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_T_6_5;
        _audioSource.Play();
    }
    private void Play_Owl_VL_1_1()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_1_1;
        _audioSource.Play();
    }
    private void Play_Owl_VL_1_2()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_1_2;
        _audioSource.Play();
    }
    private void Play_Owl_VL_1_3()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_1_3;
        _audioSource.Play();
    }
    private void Play_Owl_VL_1_4()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_1_4;
        _audioSource.Play();
    }
    private void Play_Owl_VL_1_5()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_1_5;
        _audioSource.Play();
    }
    private void Play_Owl_VL_1_6()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_1_6;
        _audioSource.Play();
    }
    private void Play_Owl_VL_1_7()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_1_7;
        _audioSource.Play();
    }
    private void Play_Owl_VL_1_8()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_1_8;
        _audioSource.Play();
    }
    private void Play_Owl_VL_1_9()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_1_9;
        _audioSource.Play();
    }
    private void Play_Owl_VL_2_1()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_2_1;
        _audioSource.Play();
    }
    private void Play_Owl_VL_2_2()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_2_2;
        _audioSource.Play();
    }
    private void Play_Owl_VL_2_3()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_2_3;
        _audioSource.Play();
    }
    private void Play_Owl_VL_2_4()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_2_4;
        _audioSource.Play();
    }
    private void Play_Owl_VL_2_5()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_2_5;
        _audioSource.Play();
    }
    private void Play_Owl_VL_3_1()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_3_1;
        _audioSource.Play();
    }
    private void Play_Owl_VL_3_2()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_3_2;
        _audioSource.Play();
    }
    private void Play_Owl_VL_3_3()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_3_3;
        _audioSource.Play();
    }
    private void Play_Owl_VL_3_4()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_3_4;
        _audioSource.Play();
    }
    private void Play_Owl_VL_3_5()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_3_5;
        _audioSource.Play();
    }
    private void Play_Owl_VL_3_6()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_3_6;
        _audioSource.Play();
    }

    private void Play_Owl_VL_Ending()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_Ending;
        _audioSource.Play();
    }

    #endregion

    private void PlayFirstCommentary()
    {
        _audioSource.clip = ResourceManager.Instance.owl_VL_T_1_1;
        _audioSource.Play();
    }

    public void PlayCommentary_T_6_1()
    {
        if (StageManager.Instance.currentStage == stage_T_6_1 || StageManager.Instance.currentStage == stage_T_5_2)
        {
            _audioSource.clip = ResourceManager.Instance.owl_VL_T_6_1;
            _audioSource.Play();
        }
    }

    public void PlayCommentary_T_5_4()
    {
        if (StageManager.Instance.currentStage == stage_T_5_4)
        {
            _audioSource.clip = ResourceManager.Instance.owl_VL_T_5_4;
            _audioSource.Play();
        }
    }

}

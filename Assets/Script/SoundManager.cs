using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager soundManger;
    [SerializeField] AudioSource soundEffects;
    [SerializeField] AudioClip turntableSE;
    [SerializeField] AudioClip getDishSE;
    [SerializeField] AudioClip[] getMoneySE;
    [SerializeField] AudioClip loseDishSE;
    [SerializeField] AudioClip gameOverSE;

    void Awake()
    {
        if(soundManger == null)
        {
            soundManger = this;
        }else if(soundManger != null)
        {
            Destroy(gameObject);
        }
    }

    public void PlaySoundEffects_TurntableSE()
    {
        if(soundEffects.clip != turntableSE) soundEffects.clip = turntableSE;
        soundEffects.PlayOneShot(turntableSE);
    }
    public void PlaySoundEffects_GetDishSE()
    {
        if(soundEffects.clip != getDishSE) soundEffects.clip = getDishSE;
        soundEffects.Play();
    }
    public void PlaySoundEffects_GetMoneySE(int value)
    {
        if(soundEffects.clip != getMoneySE[value]) soundEffects.clip = getMoneySE[value];
        soundEffects.Play();
    }
    public void PlaySoundEffects_LoseDishSE()
    {
        if(soundEffects.clip != loseDishSE) soundEffects.clip = loseDishSE;
        soundEffects.Play();
    }
    public void PlaySoundEffects_GameOverSE()
    {
        if(soundEffects.clip != gameOverSE) soundEffects.clip = gameOverSE;
        soundEffects.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseDishes : MonoBehaviour
{
    [SerializeField] GameObject hitDish; 
    [SerializeField] CreateBento createBento;

    

    void OnTriggerEnter2D(Collider2D tager)
    {        
        hitDish = tager.transform.parent.gameObject;
        SoundManager.soundManger.PlaySoundEffects_TurntableSE();
    }

    public void GetDish()
    {
        createBento.AddNumberOfItems(hitDish.GetComponent<Dish>().SetDishSize(), hitDish.GetComponent<Dish>().SetDishImage(), hitDish.GetComponent<Dish>().SetDishName());
        SoundManager.soundManger.PlaySoundEffects_GetDishSE();
    }

}

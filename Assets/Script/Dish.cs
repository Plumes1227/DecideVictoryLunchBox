using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Dish : MonoBehaviour
{
    [SerializeField] DishMenu[] dishMenus;
    
    int dishNumber;

    Text dishText;

    void OnEnable()
    {
        dishText = GetComponentInChildren<Text>();
        dishNumber = Random.Range(0 , dishMenus.Length);
        DishTextUpdate();
    }

    void DishTextUpdate()
    {
        dishText.text = dishMenus[dishNumber].DishName + dishMenus[dishNumber].DishSize;
    }

    public string SetDishName()
    {
        return dishMenus[dishNumber].DishName;
    }

    public Sprite[] SetDishImage()
    {
        return dishMenus[dishNumber].DishImages;      
    }

    public int SetDishSize()
    {
        return dishMenus[dishNumber].DishSize;
    }
}


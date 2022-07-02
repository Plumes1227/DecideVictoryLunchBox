using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]public class DishMenu
{
    [SerializeField] string dishName;
    [SerializeField] Sprite[] dishImages;
    public string DishName => dishName;
    public Sprite[] DishImages => dishImages;
    public int DishSize => DishImages.Length;
}

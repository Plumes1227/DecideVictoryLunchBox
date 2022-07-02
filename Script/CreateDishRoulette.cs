using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateDishRoulette : MonoBehaviour
{
    [SerializeField][Range(6, 12)] public int numberOfItems;
    [SerializeField] GameObject images;
    [SerializeField] List<GameObject> pieList;
    [SerializeField] Color[] color;
    Vector3 rotAu;
    Vector3 rotBu;

    int nowNmber;
    

    int colorNumber = 0;
    
    float nb = 1;
    
    void Start()
    {
        nowNmber = numberOfItems;
        for (int i = 0; i < nowNmber; i++)
        {
            rotAu.z = (-360/(float)nowNmber) * i;
            rotBu.z = (-360/(float)nowNmber)/2;
            images.GetComponent<Image>().fillAmount = nb/nowNmber;
            pieList.Add(Instantiate(images, transform.position, Quaternion.Euler(rotAu), this.transform));
            pieList[i].transform.GetChild(0).rotation = Quaternion.Euler(rotAu + rotBu);
        }
        ImageColoring();
    }

    void ImageColoring()
    {
        colorNumber = 0;
        for (int i = 0; i < pieList.Count; i++)
        {
            if(i < 2)
            {
                pieList[i].GetComponent<Image>().color = color[colorNumber++];
            }else if(pieList.Count % 5 == 1 && pieList.Count - i < 2)
            {
                if(colorNumber > 4) colorNumber = 0;
                pieList[i].GetComponent<Image>().color = color[++colorNumber];
            }else if(i > 1)
            {
                if(colorNumber > 4) colorNumber = 0;
                pieList[i].GetComponent<Image>().color = color[colorNumber++];
            }
        }            
    }


    void Update()
    { 
        if(numberOfItems > nowNmber)
        {
            AddNumber();
        }
        if(numberOfItems < nowNmber)
        {
            DisNumber();
        }
    }

    void AddNumber()
    {
        nowNmber++;
        pieList.Add(Instantiate(images, transform.position, Quaternion.Euler(rotAu), this.transform));
        for (int i = 0; i < nowNmber; i++)
        {
            rotAu.z = (-360/(float)nowNmber) * i;
            rotBu.z = (-360/(float)nowNmber)/2;
            pieList[i].GetComponent<Image>().fillAmount = nb/nowNmber;
            pieList[i].GetComponent<Transform>().rotation = Quaternion.Euler(rotAu);
            pieList[i].transform.GetChild(0).rotation = Quaternion.Euler(rotAu + rotBu);
        }
        ImageColoring();
    }

    void DisNumber()
    {
        nowNmber--;
        Destroy(pieList[nowNmber]);
        pieList.RemoveAt(nowNmber);
        for (int i = 0; i < nowNmber; i++)
        {
            rotAu.z = (-360/(float)nowNmber) * i;
            rotBu.z = (-360/(float)nowNmber)/2;
            pieList[i].GetComponent<Image>().fillAmount = nb/nowNmber;
            pieList[i].GetComponent<Transform>().rotation = Quaternion.Euler(rotAu);
            pieList[i].transform.GetChild(0).rotation = Quaternion.Euler(rotAu + rotBu);
        }
        ImageColoring();
    }
}


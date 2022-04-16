using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roulette : MonoBehaviour
{
    [SerializeField] ChooseDishes chooseDishes;
    [SerializeField][Min(0)] float rotSpeed ;

    bool isOnTurn = false;
    public bool IsOnTurn => isOnTurn;



    void Update()
    {
        //旋轉
        transform.Rotate(0 ,0 , rotSpeed);
        rotSpeed *= 0.985f;     //動力持續減少        

        if(isOnTurn)
        {
            InTurn();
        }
    }

    public void StartTurn()
    {
        if(isOnTurn) return;
        rotSpeed = 50 * Random.Range(1f,1.5f);     //重新補充50動力
        isOnTurn = true;
    }

    public void InTurn()
    {

        if(rotSpeed < 0.5f) 
        {
            rotSpeed = 0;
            isOnTurn = false;
            chooseDishes.GetDish();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] CreateDishRoulette createDishRoulette;
    [SerializeField] Roulette roulette;
    [SerializeField] CreateBento createBento;

    [SerializeField] GameObject MenuUI;
    [SerializeField] GameObject GamePlayUI;
    [SerializeField] GameObject GameOverUI;


    public void ChangeDishButton(int amount)
    {
        if(roulette.IsOnTurn) return;
        if(scoreManager.NowMoney < amount) return;
        roulette.GetComponent<Transform>().gameObject.SetActive(false);
        roulette.GetComponent<Transform>().gameObject.SetActive(true);
        scoreManager.DeductMoney(amount);
    }
    public void BetDishButton(int amount)
    {
        if(roulette.IsOnTurn) return;
        if(scoreManager.NowMoney < amount) return;
        scoreManager.DeductMoney(amount);
        roulette.StartTurn();
    }
    public void SellBentoButton()
    {
        if(roulette.IsOnTurn) return;
        if(createBento.NumberOfItems == 0) return;
        roulette.GetComponent<Transform>().gameObject.SetActive(false);
        roulette.GetComponent<Transform>().gameObject.SetActive(true);
        scoreManager.AddMoney(createBento.SellBento());
    }

    public void AddDishItemButton(int amount)
    {
        if(roulette.IsOnTurn) return;
        if(scoreManager.NowMoney < amount) return;
        if(createDishRoulette.numberOfItems >= 12) return;
        createDishRoulette.numberOfItems ++;
        scoreManager.DeductMoney(amount);
    }
    public void DisDishItemButton(int amount)
    {
        if(roulette.IsOnTurn) return;
        if(scoreManager.NowMoney < amount) return;
        if(createDishRoulette.numberOfItems <= 6) return;
        createDishRoulette.numberOfItems --;
        scoreManager.DeductMoney(amount);
    }

    public void ShowExplainButton(Canvas canvas)
    {
        canvas.enabled = true;
    }
    public void CloseExplainButton(Canvas canvas)
    {
        canvas.enabled = false;
    }

    public void StartGameButton()
    {
        MenuUI.SetActive(false);
        GamePlayUI.SetActive(true);
    }

    public void GoToMenuButton()
    {
        if(roulette.IsOnTurn) return;
        MenuUI.SetActive(true);
        GamePlayUI.SetActive(false);
        GameOverUI.SetActive(false);
        scoreManager.RemasteredMoney();
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }
}

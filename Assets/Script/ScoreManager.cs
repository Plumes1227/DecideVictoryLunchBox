using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManager;
    [SerializeField] GameObject gamePlayUi;
    [SerializeField] GameObject gameOverUi;
    [SerializeField] Roulette roulette;
    [SerializeField] int money;
    int nowMoney;
    public int NowMoney => nowMoney;
    [SerializeField] Text money_Text;

    void Awake()
    {
        if(scoreManager == null)
        {
            scoreManager = this;
        }else if(scoreManager != null)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        nowMoney = money;
        money_Text.text = ""+ nowMoney;
    }

    public void RemasteredMoney()
    {
        nowMoney = money;
        money_Text.text = ""+ nowMoney;
    }

    public void DeductMoney(int amount)
    {
        if(roulette.IsOnTurn) return;
        if(amount > nowMoney) return;
        nowMoney -= amount;
        money_Text.text = ""+ nowMoney;
    }

    public void AddMoney(int amount)
    {
        nowMoney += amount;
        money_Text.text = ""+ nowMoney;

        if(nowMoney < 20)
        {
            gamePlayUi.SetActive(false);
            gameOverUi.SetActive(true);
        }
    }
}

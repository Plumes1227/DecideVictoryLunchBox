using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateBento : MonoBehaviour
{
    [SerializeField] GameObject addScore;
    [SerializeField] GameObject winningTheLottery;
    [SerializeField][Min(0)] int numberOfItems;
    public int NumberOfItems => numberOfItems;
    [SerializeField] int maxNumberOfItems;
    [SerializeField] GameObject dishImages;
    [SerializeField] List<GameObject> pieList;
    [SerializeField] List<string> BentoNameList;
    [SerializeField] List<int> BentoNumberList;
    [SerializeField] string CNameCombine;
    [SerializeField] int BentoScore;

    void Update()
    {
        if(numberOfItems > maxNumberOfItems)
        {
            ClearDish();
            SoundManager.soundManger.PlaySoundEffects_LoseDishSE();
            ScoreManager.scoreManager.AddMoney(0);
            //爆點
        }
        if(numberOfItems > pieList.Count)
        {
            //測試用，待刪除
            AddDish(null);
        }        
    }

    public void AddNumberOfItems(int value, Sprite[] image, string name)
    {
        numberOfItems += value;
        BentoNumberList.Add(value);
        BentoNameList.Add(name);
        
        for (int i = 0; i < image.Length; i++)
        {
            AddDish(image[i]);    
        }
    }

    void AddDish(Sprite image)
    {
        if(numberOfItems > maxNumberOfItems) return;
        pieList.Add(Instantiate(dishImages, this.transform));
        pieList[pieList.Count-1].GetComponentInChildren<Image>().sprite = image;
        
    }

    void ClearDish()
    {
        for (int i = 0; i < pieList.Count; i++)
        {
            Destroy(pieList[i]);
        }
        numberOfItems = 0;
        pieList.Clear();
        BentoNameList.Clear();
        BentoNumberList.Clear();
    }

    public int SellBento()
    {
        winningTheLottery.GetComponent<Text>().text = "";
        CNameCombine = null;
        BentoScore = 0;
        BentoScore += numberOfItems * 10;
        if(numberOfItems == 6) BentoScore += 40;        //塞滿便當獎勵

        for (int i = 0; i < BentoNameList.Count; i++)
        {
            CNameCombine += BentoNameList[i];
        }

        //特殊組合判斷
        if(BentoNumberList.Count == 2 && BentoNumberList.Contains(2) && BentoNumberList.Contains(3) && CNameCombine.Contains("咖哩")) { BentoScore += 50; winningTheLottery.GetComponent<Text>().text = "咖哩雞腿飯"; }
        if(BentoNumberList.Count == 2 && BentoNumberList.Contains(2) && BentoNumberList.Contains(3) && CNameCombine.Contains("蛋")) { BentoScore += 50; winningTheLottery.GetComponent<Text>().text = "雞腿蛋包飯"; }
        if(BentoNumberList.Count == 3 && BentoNumberList.Contains(1) && BentoNumberList.Contains(2) && BentoNumberList.Contains(3) && CNameCombine.Contains("咖哩")) { BentoScore += 100; winningTheLottery.GetComponent<Text>().text = "健康\n咖哩雞腿飯"; }
        if(BentoNumberList.Count == 3 && BentoNumberList.Contains(1) && BentoNumberList.Contains(2) && BentoNumberList.Contains(3) && CNameCombine.Contains("蛋")) { BentoScore += 100; winningTheLottery.GetComponent<Text>().text = "健康\n雞腿蛋包飯"; }
        if(CNameCombine == "咖哩咖哩咖哩") { BentoScore += 200; winningTheLottery.GetComponent<Text>().text = "Ex咖哩飯"; }
        if(CNameCombine == "蛋蛋蛋") { BentoScore += 200; winningTheLottery.GetComponent<Text>().text = "蛋蛋的哀傷"; }
        if(BentoNumberList.Count == 6) { BentoScore += 300; winningTheLottery.GetComponent<Text>().text = "佛系便當"; }
        if(CNameCombine == "雞腿雞腿") { BentoScore += 500; winningTheLottery.GetComponent<Text>().text = "雙倍快樂\n雞腿便當"; }
        if(CNameCombine == "青菜青菜青菜青菜青菜青菜") { BentoScore += 1000;  winningTheLottery.GetComponent<Text>().text = "對菜\n情有獨鍾"; }
        if(CNameCombine == "三色豆三色豆三色豆三色豆三色豆三色豆") { BentoScore += 1000;  winningTheLottery.GetComponent<Text>().text = "對三色豆\n情有獨鍾"; }
        if(CNameCombine == "胡蘿蔔胡蘿蔔胡蘿蔔胡蘿蔔胡蘿蔔胡蘿蔔") { BentoScore += 1000;  winningTheLottery.GetComponent<Text>().text = "對胡蘿蔔\n情有獨鍾"; }

        //獎勵音效判別
        if(BentoScore < 100)
        {
            SoundManager.soundManger.PlaySoundEffects_GetMoneySE(0);
        }
        else if(BentoScore == 100)
        {
            SoundManager.soundManger.PlaySoundEffects_GetMoneySE(1);
        }
        else if(BentoScore == 200)
        {
            SoundManager.soundManger.PlaySoundEffects_GetMoneySE(2);
        }
        else if(BentoScore == 300)
        {
            SoundManager.soundManger.PlaySoundEffects_GetMoneySE(3);
        }
        else if(BentoScore == 400)
        {
            SoundManager.soundManger.PlaySoundEffects_GetMoneySE(4);
        }
        else if(BentoScore == 600)
        {
            SoundManager.soundManger.PlaySoundEffects_GetMoneySE(5);
        }
        else if(BentoScore == 1400)
        {
            SoundManager.soundManger.PlaySoundEffects_GetMoneySE(6);
        }
        addScore.GetComponent<Text>().text = "+" + BentoScore;
        addScore.SetActive(true);
        winningTheLottery.SetActive(true);
        ClearDish();
        return BentoScore;
    }
    
    void OnDisable()
    {
        ClearDish();
    }
}

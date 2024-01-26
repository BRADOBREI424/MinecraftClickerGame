using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class Reward : MonoBehaviour
{
    private float _currentBonus;
    private Button _button;
    private TMP_Text _bonusText;

    public static Action<float> WatchAd;
    private void Start()
    {
        _button = GameObject.Find("RewardAd").GetComponent<Button>();
        _bonusText = GameObject.Find("BonusCount").GetComponent<TMP_Text>();
        DisableReward();
        InvokeRepeating("EnableReward", 30, 60);
    }
    private void EnableReward()
    {
        _currentBonus = Money.CurrentValuue * 20 /100;
        _button.gameObject.SetActive(true);
        _bonusText.gameObject.SetActive(true);
        _bonusText.text = Convert.ToString(Math.Round(_currentBonus,1));
    }
    private void DisableReward()
    {
        _button.gameObject.SetActive(false);
        _bonusText.gameObject.SetActive(false);
    }
    
    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += AddMoney;
        YandexGame.ErrorVideoEvent += ErrorReward;
    }
    private void OnDisable() 
    {
        YandexGame.RewardVideoEvent -= AddMoney;
        YandexGame.ErrorVideoEvent -= ErrorReward;
    }
    private void AddMoney(int id)
    {
       WatchAd?.Invoke(_currentBonus);
       DisableReward();
    }
    private void ErrorReward()
    {
        Debug.Log("Не удача");
    }

    public void OpenRewardAd()
    {
        YandexGame.RewVideoShow(0);
    }
}

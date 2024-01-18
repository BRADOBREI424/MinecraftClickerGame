using System;
using TMPro;
using UnityEngine;

public class Buy : MonoBehaviour
{
    private TMP_Text MoneyCountUI;
    public bool isUpgrade;
    public void BuyUpgrade(float Upgrade, float Cost)
    {
        MoneyCountUI = GameObject.Find("Money").GetComponent<TMP_Text>();
        if (Money.MoneyCount >= Cost)
        {
            Money.MultipleMoney += Upgrade;
            Money.MoneyCount -= Cost;
            MoneyCountUI.text = Convert.ToString(Money.MoneyCount);
            isUpgrade = true;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class BuyUpgrade : MonoBehaviour
{
    private Image Icon;
    private Sprite[] UpgradeSprites;
    private TMP_Text Level;
    private TMP_Text Cost;
    private TMP_Text Bonus;
    private UpgradeBonuses upgradeBonuses;
    private UpgradeCosts upgradeCosts;
    private Animator UpgradeCancled;

    private void Start() 
    {
        upgradeBonuses = GetComponent<UpgradeBonuses>();
        upgradeCosts = GetComponent<UpgradeCosts>();
    }
    public void Buy(string UpgradeName)
    {
        try
        {
            GetUpgrade(UpgradeName);
            if(Money.MoneyCount >= float.Parse(Cost.text))
            {
                Money.MoneyCount -= float.Parse(Cost.text);
                int CurentLevel = int.Parse(Level.text) + 1;
                Level.text = Convert.ToString(CurentLevel);
                Money.MultipleMoney += float.Parse(Bonus.text);
                SetUpgradeStats(UpgradeName);
            }
            else
            {
                UpgradeCancled.Play("UpgradeCancled");
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
        
    }
    private void GetUpgrade(string UpgradeName)
    {
        this.UpgradeCancled =GetComponent<Animator>();
        UpgradeSprites = Resources.LoadAll<Sprite>($"Sprites/Upgrades/{UpgradeName}");
        Icon = GameObject.Find($"{UpgradeName}/UpgradeIcon").GetComponent<Image>();
        Level = GameObject.Find($"{UpgradeName}/UpgradeLevel").GetComponent<TMP_Text>();
        Cost = GameObject.Find($"{UpgradeName}/UpgradeCost").GetComponent<TMP_Text>();
        Bonus = GameObject.Find($"{UpgradeName}/UpgradeValue").GetComponent<TMP_Text>();
    }

    public void SetUpgradeStats(string UpgradeName)
    {
        float[] Bonuses = upgradeBonuses.SetUpgradeBonuses()[UpgradeName];
        int[] Costs = upgradeCosts.SetUpgradeCosts()[UpgradeName];
        if(int.Parse(Level.text) < 25)
        {
            Icon.sprite = UpgradeSprites[0];
            Bonus.text = Convert.ToString(Bonuses[0]);
            Cost.text = Convert.ToString(int.Parse(Cost.text) + Costs[0]);
        }
        else if(int.Parse(Level.text) < 50)
        {
            Icon.sprite = UpgradeSprites[1];
            Bonus.text = Convert.ToString(Bonuses[1]);
            Cost.text = Convert.ToString(int.Parse(Cost.text) + Costs[1]);
        }
        else if(int.Parse(Level.text) < 75)
        {
            Icon.sprite = UpgradeSprites[2];
            Bonus.text = Convert.ToString(Bonuses[2]);
            Cost.text = Convert.ToString(int.Parse(Cost.text) + Costs[2]);
        }
        else if(int.Parse(Level.text) < 100)
        {
            Icon.sprite = UpgradeSprites[3];
            Bonus.text = Convert.ToString(Bonuses[3]);
            Cost.text = Convert.ToString(int.Parse(Cost.text) + Costs[3]);
        }
        else if(int.Parse(Level.text) < 125)
        {
            Icon.sprite = UpgradeSprites[4];
            Bonus.text = Convert.ToString(Bonuses[4]);
            Cost.text = Convert.ToString(int.Parse(Cost.text) + Costs[4]);
        }
        else
        {
            GameObject.Find($"{UpgradeName}/BuyUpgrade").GetComponent<Button>().enabled = false;
            GameObject.Find($"{UpgradeName}/BuyUpgradeText").GetComponent<TMP_Text>().text = "МАКС. УРОВЕНЬ";
        }
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Shovel : MonoBehaviour
{
    private Buy BuyLink;
    private TMP_Text ShovelLevelUI;
    private TMP_Text ShovelCostUI;
    private Button ButtonBuyShovel;
    private TMP_Text BuyShovelText;
    private TMP_Text Upgrade;
    private Image ActualShovel;
    private float CostUp;

    private void Start() 
    {
        BuyLink = GetComponent<Buy>();
        ActualShovel = GameObject.Find("ShovelIcon").GetComponent<Image>();
        ButtonBuyShovel = GameObject.Find("BuyShovel").GetComponent<Button>();
        BuyShovelText = GameObject.Find("BuyShovelText").GetComponent<TMP_Text>();
    }

    private void SetShovel(string ShovelName)
    {
        ActualShovel.sprite = Resources.Load<Sprite>($"Sprites/Upgrades/Shovels/{ShovelName}");
    }

    private void GetShovel()
    {
        ShovelLevelUI = GameObject.Find("ShovelLevel").GetComponent<TMP_Text>();
        ShovelCostUI = GameObject.Find("ShovelCost").GetComponent<TMP_Text>();
        Upgrade = GameObject.Find("ShovelUpgradeValue").GetComponent<TMP_Text>();
        int ShovelLevel = int.Parse(ShovelLevelUI.text);

        if(ShovelLevel <= 25)
        {
            SetShovel("WoodShovel");
            Upgrade.text = "0.5";
            CostUp = 750;
        }
        else if(ShovelLevel <= 50)
        {
            SetShovel("StoneShovel");
            Upgrade.text = "0.7";
            CostUp = 900;
        }
        else if(ShovelLevel <= 75)
        {
            SetShovel("IronShovel");
            Upgrade.text = "1";
            CostUp = 1050;
        }
        else if(ShovelLevel <= 100)
        {
            SetShovel("GoldShovel");
            Upgrade.text = "1.2";
            CostUp = 1200;
        }
        else if(ShovelLevel <= 125)
        {
            SetShovel("DiamondShovel");
            Upgrade.text = "1.5";
            CostUp = 1350;
        }
        else if(ShovelLevel > 125)
        {
            BuyShovelText.text = "МАКС. УРОВЕНЬ";
            ButtonBuyShovel.enabled = false;
        }
    }

    public void BuyShovel()
    {
        try
        {
            GetShovel();
            BuyLink.BuyUpgrade(float.Parse(Upgrade.text), float.Parse(ShovelCostUI.text));
            if(BuyLink.isUpgrade)
            {
                int Level = int.Parse(ShovelLevelUI.text);
                float Cost = float.Parse(ShovelCostUI.text);
                Level += 1;
                Cost += CostUp;
                ShovelLevelUI.text = Convert.ToString(Level);
                ShovelCostUI.text = Convert.ToString(Cost);
                BuyLink.isUpgrade = false;
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
    }
}

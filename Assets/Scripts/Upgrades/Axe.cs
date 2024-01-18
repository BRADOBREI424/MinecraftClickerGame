using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Axe : MonoBehaviour
{
    private Buy BuyLink;
    private TMP_Text AxeLevel;
    private TMP_Text AxeCost;
    private Button ButtonBuyAxe;
    private TMP_Text BuyAxeText;
    private TMP_Text Upgrade;
    private Image ActualAxe;
    private float CostUp;

    private void Start() 
    {
        BuyLink = GetComponent<Buy>();
        ActualAxe = GameObject.Find("AxeIcon").GetComponent<Image>();
        ButtonBuyAxe = GameObject.Find("BuyAxe").GetComponent<Button>();
        BuyAxeText = GameObject.Find("BuyAxeText").GetComponent<TMP_Text>();
    }

    private void SetAxe(string AxeName)
    {
        ActualAxe.sprite = Resources.Load<Sprite>($"Sprites/Upgrades/Axes/{AxeName}");
    }

    private void GetAxe()
    {
        AxeLevel = GameObject.Find("AxeLevel").GetComponent<TMP_Text>();
        AxeCost = GameObject.Find("AxeCost").GetComponent<TMP_Text>();
        Upgrade = GameObject.Find("AxeUpgradeValue").GetComponent<TMP_Text>();
        int Level = int.Parse(AxeLevel.text);

        if(Level <= 25)
        {
            SetAxe("WoodAxe");
            Upgrade.text = "1.0";
            CostUp = 2500;
        }
        else if(Level <= 50)
        {
            SetAxe("StoneAxe");
            Upgrade.text = "1.2";
            CostUp = 3000;
        }
        else if(Level <= 75)
        {
            SetAxe("IronAxe");
            Upgrade.text = "1.4";
            CostUp = 3500;
        }
        else if(Level <= 100)
        {
            SetAxe("GoldAxe");
            Upgrade.text = "1.7";
            CostUp = 4000;
        }
        else if(Level <= 125)
        {
            SetAxe("DiamondAxe");
            Upgrade.text = "2.0";
            CostUp = 4500;
        }
        else if(Level > 125)
        {
            BuyAxeText.text = "МАКС. УРОВЕНЬ";
            ButtonBuyAxe.enabled = false;
        }
    }

    public void BuyAxe()
    {
        try
        {
            GetAxe();
            BuyLink.BuyUpgrade(float.Parse(Upgrade.text), float.Parse(AxeCost.text));
            if(BuyLink.isUpgrade)
            {
                int Level = int.Parse(AxeLevel.text);
                float Cost = float.Parse(AxeCost.text);
                Level += 1;
                Cost += CostUp;
                AxeLevel.text = Convert.ToString(Level);
                AxeCost.text = Convert.ToString(Cost);
                BuyLink.isUpgrade = false;
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
    }
}

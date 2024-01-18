using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

public class Pickaxe : MonoBehaviour
{
    private Buy BuyLink;
    private TMP_Text PickaxeLevel;
    private TMP_Text PickaxeCost;
    private Button ButtonBuyPickaxe;
    private TMP_Text BuyPickaxeText;
    private TMP_Text Upgrade;
    private Image ActualPickaxe;
    private float CostUp;

    private void Start() 
    {
        BuyLink = GetComponent<Buy>();
        ActualPickaxe = GameObject.Find("PickaxeIcon").GetComponent<Image>();
        ButtonBuyPickaxe = GameObject.Find("BuyPickaxe").GetComponent<Button>();
        BuyPickaxeText = GameObject.Find("BuyPickaxeText").GetComponent<TMP_Text>();
    }

    private void ChangePickaxe(string NamePickaxe)
    {
        ActualPickaxe.sprite = Resources.Load<Sprite>($"Sprites/Upgrades/Pickaxes/{NamePickaxe}");
    }

    private void GetPickaxe()
    {
        PickaxeLevel = GameObject.Find("PickaxeLevel").GetComponent<TMP_Text>();
        PickaxeCost = GameObject.Find("PickaxeCost").GetComponent<TMP_Text>();
        Upgrade = GameObject.Find("PickaxeUpgradeValue").GetComponent<TMP_Text>();
        int Level = int.Parse(PickaxeLevel.text);

        if(Level < 25)
        {
            ChangePickaxe("WoodPickaxe");
            Upgrade.text = "3.0";
            CostUp = 5000;
        }
        else if(Level < 50)
        {
            ChangePickaxe("StonePickaxe");
            Upgrade.text = "5.0";
            CostUp = 7500;
        }
        else if(Level < 75)
        {
            ChangePickaxe("IronPickaxe");
            Upgrade.text = "7.0";
            CostUp = 10000;
        }
        else if(Level < 100)
        {
            ChangePickaxe("GoldPickaxe");
            Upgrade.text = "10.0";
            CostUp = 12500;
        }
        else if(Level < 125)
        {
            ChangePickaxe("DiamondPickaxe");
            Upgrade.text = "15.0";
            CostUp = 15000;
        }
        else if(Level > 125)
        {
            BuyPickaxeText.text = "МАКС. УРОВЕНЬ";
            ButtonBuyPickaxe.enabled = false;
        }
    }

    public void BuyPickaxe()
    {
        try
        {
            GetPickaxe();
            BuyLink.BuyUpgrade(float.Parse(Upgrade.text), float.Parse(PickaxeCost.text));
            if(BuyLink.isUpgrade)
            {
                int Level = int.Parse(PickaxeLevel.text);
                float Cost = float.Parse(PickaxeCost.text);
                Level += 1;
                Cost += CostUp;
                PickaxeLevel.text = Convert.ToString(Level);
                PickaxeCost.text = Convert.ToString(Cost);
                BuyLink.isUpgrade = false;
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
    }
}

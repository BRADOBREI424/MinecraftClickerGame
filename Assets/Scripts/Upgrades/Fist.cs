using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Fist : MonoBehaviour
{
   private Buy BuyLink;
   private TMP_Text FistLevelUI;
   private TMP_Text FistCostUI;
   private Button BuyFist;
   private TMP_Text BuyFistText;
   private int FistLevel;
   private float Cost;
   private TMP_Text Upgrade;
   private Image ActualFist;
   private float CostUp;

   private void Start() 
   {
        BuyLink = GetComponent<Buy>();
        FistLevelUI = GameObject.Find("FistLevel").GetComponent<TMP_Text>();
        FistLevel = int.Parse(FistLevelUI.text);
        FistCostUI = GameObject.Find("FistCost").GetComponent<TMP_Text>();
        ActualFist = GameObject.Find("FistIcon").GetComponent<Image>();
        BuyFist = GameObject.Find("BuyFist").GetComponent<Button>();
        BuyFistText = GameObject.Find("BuyFistText").GetComponent<TMP_Text>();
        Cost = 25;
        
   }

   private void ChangeFist()
   {
        FistLevelUI = GameObject.Find("FistLevel").GetComponent<TMP_Text>();
        FistLevel = int.Parse(FistLevelUI.text);
        Upgrade = GameObject.Find("FistUpgradeValue").GetComponent<TMP_Text>();
    
        if (FistLevel <= 25)
        {
            SetFist("Fist");
            Upgrade.text = Convert.ToString(0.1f);
            CostUp = 5;
        }
        else if (FistLevel <= 50)
        {
            SetFist("LeatherFist");
            Upgrade.text = Convert.ToString(0.2f);
            CostUp = 50;
        }
        else if (FistLevel <= 75)
        {
            SetFist("IronFist");
            Upgrade.text = Convert.ToString(0.3f);
            CostUp = 500;
        }
        else if (FistLevel <= 100)
        {
            SetFist("GoldFist");
            Upgrade.text = Convert.ToString(0.4f);
            CostUp = 5000;
        }
        else if (FistLevel <= 125)
        {
            SetFist("DiamondFist");
            Upgrade.text = Convert.ToString(0.5f);
            CostUp = 50000;
        }
        else if (FistLevel > 125)
        {
            BuyFistText.text = "МАКС. УРОВЕНЬ";
            BuyFist.enabled = false;
        }
   }

   public void BuyFistUpgrade()
   {
        try
        {
            ChangeFist();
            BuyLink.BuyUpgrade(float.Parse(Upgrade.text), Cost);

            if(BuyLink.isUpgrade == true)
            {
                FistLevel += 1;
                FistLevelUI.text = Convert.ToString(FistLevel);
                Cost += CostUp;
                FistCostUI.text = Convert.ToString(Cost);
                BuyLink.isUpgrade = false;
            }
            
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
   }

   private void SetFist(string NameFist)
   {
       ActualFist.sprite = Resources.Load<Sprite>($"Sprites/Upgrades/Fists/{NameFist}");
   }
}

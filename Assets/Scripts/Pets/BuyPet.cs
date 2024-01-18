using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class BuyPet : MonoBehaviour
{
    private Image Icon;
    private Sprite[] PetSprites;
    private TMP_Text Level;
    private TMP_Text Cost;
    private TMP_Text Bonus;
    private PetBonuses petBonuses;
    private PetCosts petCosts;
    private void Start() 
    {
        petBonuses = GetComponent<PetBonuses>();
        petCosts = GetComponent<PetCosts>();
    }
    public void Buy(string PetName)
    {
        GetPet(PetName);
        if(Money.MoneyCount >= float.Parse(Cost.text))
        {
            int CurentLevel = int.Parse(Level.text) + 1;
            Level.text = Convert.ToString(CurentLevel);
            SetPetStats(PetName);
        }
    }

    private void GetPet(string PetName)
    {
        
        PetSprites = Resources.LoadAll<Sprite>($"Sprites/Pets/{PetName}");
        Icon = GameObject.Find($"{PetName}/PetIcon").GetComponent<Image>();
        Level = GameObject.Find($"{PetName}/PetLevel").GetComponent<TMP_Text>();
        Cost = GameObject.Find($"{PetName}/PetCost").GetComponent<TMP_Text>();
        Bonus = GameObject.Find($"{PetName}/PetBonus").GetComponent<TMP_Text>();
    }
    public void SetPetStats(string PetName)
    {
        float[] Bonuses = petBonuses.SetPetBonuses()[PetName];
        int[] Costs = petCosts.SetPetCosts()[PetName];
        if(int.Parse(Level.text) < 25)
        {
            Icon.sprite = PetSprites[0];
            Bonus.text = Convert.ToString(Bonuses[0]);
            Cost.text = Convert.ToString(int.Parse(Cost.text) + Costs[0]);
        }
        else if(int.Parse(Level.text) < 50)
        {
            Icon.sprite = PetSprites[1];
            Bonus.text = Convert.ToString(Bonuses[1]);
            Cost.text = Convert.ToString(int.Parse(Cost.text) + Costs[1]);
        }
        else if(int.Parse(Level.text) < 75)
        {
            Icon.sprite = PetSprites[2];
            Bonus.text = Convert.ToString(Bonuses[2]);
            Cost.text = Convert.ToString(int.Parse(Cost.text) + Costs[2]);
        }
        else
        {
            GameObject.Find($"{PetName}/BuyPet").GetComponent<Button>().enabled = false;
            GameObject.Find($"{PetName}/BuyPetText").GetComponent<TMP_Text>().text = "МАКС. УРОВЕНЬ";
        }

    }
}

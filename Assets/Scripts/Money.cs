using System;
using UnityEngine;
using TMPro;
using System.Collections;

public class Money : MonoBehaviour
{
    private Block BlockLink;
    private TMP_Text MoneyCountUI;
    public static float MoneyCount {get; set;}
    public static float MultipleMoney {get; set;}
    public static float Bonus{get;set;}

    private void Start() 
    {
        MoneyCountUI = GameObject.Find("Money").GetComponent<TMP_Text>();
        MoneyCount = float.Parse(MoneyCountUI.text);
        BlockLink = GetComponent<Block>();
        MultipleMoney = 1f;
        Bonus = 0;
        StartCoroutine(UpdateMoneyEventTick());
    }

    public void GetMoney()
    {
            if(BlockLink.DestroyedBlock == "Coblestone")
            {
                MoneyCount += 1 * MultipleMoney;
            }
            else if(BlockLink.DestroyedBlock == "Coper")
            {
                MoneyCount += 3 * MultipleMoney;
            }
            else if(BlockLink.DestroyedBlock == "Gold")
            {
                MoneyCount += 5 * MultipleMoney;
            }
            else if(BlockLink.DestroyedBlock == "Diamond")
            {
                MoneyCount += 12 * MultipleMoney;
            }
            else if(BlockLink.DestroyedBlock == "Ruby")
            {
                MoneyCount += 15 * MultipleMoney;
            }
            else if(BlockLink.DestroyedBlock == "Emerald")
            {
                MoneyCount += 20 * MultipleMoney;
            }
            MoneyCountUI.text = Convert.ToString(MoneyCount);
    }

    IEnumerator UpdateMoneyEventTick()
    {
        while(true)
        {
                MoneyCount += Bonus;
                MoneyCountUI.text = Convert.ToString(MoneyCount);
                yield return new WaitForSeconds(1);
        }
    }
}

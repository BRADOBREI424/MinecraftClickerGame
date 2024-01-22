using System;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    private TMP_Text _moneyText;
    [SerializeField] private static float _currentValue;
    public static float CurrentValuue => _currentValue;
    [SerializeField] private float _upgradeBonus;

    

    private void Start() 
    {
        this._moneyText = GetComponent<TMP_Text>();
        // StartCoroutine(UpdateMoneyEventTick());
    }

    private void OnEnable() {
        Block.DestroyBlock += GetMoney;
        Upgrade.Purchase += DecreaseMoney;
        Upgrade.SetBonus += SetUpgradeBonus;
    }
    private void OnDisable() {
        Block.DestroyBlock -= GetMoney;
        Upgrade.Purchase -= DecreaseMoney;
        Upgrade.SetBonus -= SetUpgradeBonus;
    }

    public void GetMoney(int DestroyedBlock)
    {
            if(DestroyedBlock == 0)
            {
                _currentValue += 1 + _upgradeBonus;
            }
            else if(DestroyedBlock == 1)
            {
                _currentValue += 3 + _upgradeBonus;
            }
            else if(DestroyedBlock == 2)
            {
                _currentValue += 5 + _upgradeBonus;
            }
            else if(DestroyedBlock == 3)
            {
                _currentValue += 12 + _upgradeBonus;
            }
            else if(DestroyedBlock == 4)
            {
                _currentValue += 15 + _upgradeBonus;
            }
            else if(DestroyedBlock == 5)
            {
                _currentValue += 20 + _upgradeBonus;
            }
            _moneyText.text = Convert.ToString(_currentValue);
    }

    private void DecreaseMoney(float cost)
    {
        _currentValue -= cost;
        _moneyText.text = Convert.ToString(_currentValue);
    }
    private void SetUpgradeBonus(float bonus)
    {
        _upgradeBonus += bonus;
    }
    

    // IEnumerator UpdateMoneyEventTick()
    // {
    //     while(true)
    //     {
                
    //             MoneyCountUI.text = Convert.ToString(MoneyCount);
    //             yield return new WaitForSeconds(1);
    //     }
    // }
}

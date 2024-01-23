using System;
using UnityEngine;
using TMPro;
using System.Collections;
using Unity.Mathematics;

public class Money : MonoBehaviour
{
    private TMP_Text _moneyText;
    [SerializeField] private static float _currentValue;
    public static float CurrentValuue => _currentValue;
    [SerializeField] private float _upgradeBonus;
    [SerializeField] private float _petBonus;

    

    private void Start() 
    {
        this._moneyText = GetComponent<TMP_Text>();
        _currentValue = PlayerPrefs.GetFloat("Money");
        _upgradeBonus = PlayerPrefs.GetFloat("UpgradeBonus");
        _petBonus = PlayerPrefs.GetFloat("PetBonus");
        _moneyText.text = RoundCurrentValue();
        StartCoroutine(UpdateMoneyEventTick());
        StartCoroutine(SaveEvent());
    }

    private void OnEnable() {
        Block.DestroyBlock += GetMoney;
        Upgrade.Purchase += DecreaseMoney;
        Upgrade.SetBonus += SetUpgradeBonus;
        Pet.Purchase += DecreaseMoney;
        Pet.SetBonus += SetPetBonus;
    }
    private void OnDisable() {
        Block.DestroyBlock -= GetMoney;
        Upgrade.Purchase -= DecreaseMoney;
        Upgrade.SetBonus -= SetUpgradeBonus;
        Pet.Purchase -= DecreaseMoney;
        Pet.SetBonus -= SetPetBonus;
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
            _moneyText.text = RoundCurrentValue();
    }

    private void DecreaseMoney(float cost)
    {
        _currentValue -= cost;
        _moneyText.text = RoundCurrentValue();
        SaveCurrentMoney();
    }
    private void SetUpgradeBonus(float bonus)
    {
        _upgradeBonus += bonus;
        PlayerPrefs.SetFloat("UpgradeBonus", _upgradeBonus);
    }
    private void SetPetBonus(float bonus)
    {
        _petBonus += bonus;
        PlayerPrefs.SetFloat("PetBonus", _petBonus);
        
    }
    private string RoundCurrentValue() {return Convert.ToString(Math.Round(_currentValue, 1));}

    IEnumerator UpdateMoneyEventTick()
    {
        while(true)
        {
            _currentValue += _petBonus;
            _moneyText.text = RoundCurrentValue();
            yield return new WaitForSeconds(1);
        }
    }
    IEnumerator SaveEvent()
    {
        while(true)
        {
            SaveCurrentMoney();
            yield return new WaitForSeconds(10);
        }
    }
    private void SaveCurrentMoney()
    {
        PlayerPrefs.SetFloat("Money", _currentValue);
    }
}

using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    
    [SerializeField] private int _level;
    [SerializeField] private float[] _bonuses;
    [SerializeField] private float[] _costs;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField]private float _currentCost;
    private float _currentBonus;
    private int _currentStage;
    public static Action<float> Purchase;
    public static Action<float> SetBonus;

    private int IdentifyStage()
    {
        if(_level <= 25)
        {
            return 0;
        }
        else if(_level <= 50)
        {
            return 1;
        }
        else if(_level <= 75)
        {
            return 2;
        }
        else if(_level <= 100)
        {
            return 3;
        }
        else if(_level < 125)
        {
            return 4;
        }
        else
        {
            return -1;
        }
    }

    private void SetStats()
    {
       
        if (_currentStage == -1)
        {
            GameObject.Find($"{this.name}/BuyUpgrade").GetComponent<Button>().enabled = false;
            GameObject.Find($"{this.name}/BuyUpgradeText").GetComponent<TMP_Text>().text = "МАКС. УРОВЕНЬ";
        }
        else
        {
            
            _currentBonus = _bonuses[_currentStage];
            GameObject.Find($"{this.name}/UpgradeIcon").GetComponent<Image>().sprite = _sprites[_currentStage];
            GameObject.Find($"{this.name}/UpgradeCost").GetComponent<TMP_Text>().text = Convert.ToString(_currentCost);
            GameObject.Find($"{this.name}/UpgradeValue").GetComponent<TMP_Text>().text = Convert.ToString(_currentBonus);
            GameObject.Find($"{this.name}/UpgradeLevel").GetComponent<TMP_Text>().text = Convert.ToString(_level);
        }
    }
    private void Start() 
    {
        _level = PlayerPrefs.GetInt($"{this.name}Level");
        if(this._level > 0) 
        {
            _currentCost = PlayerPrefs.GetFloat($"{this.name}Cost");
            _currentStage = PlayerPrefs.GetInt($"{this.name}Stage");
            SetStats();
        }
    }
    public void Buy()
    {
        if(Money.CurrentValuue >= _currentCost)
        {
            _currentStage = IdentifyStage();
            Purchase?.Invoke(_currentCost);
            _currentCost += _costs[_currentStage];
            _level += 1;
            SetStats();
            SetBonus?.Invoke(_currentBonus);
            Save();
        }
        else
        {
            Button BuyButton = GameObject.Find($"{this.name}/BuyUpgrade").GetComponent<Button>();
            BuyButton.animator.Play("UpgradeCancled");
        }
    }

    private void Save()
    {
        PlayerPrefs.SetFloat($"{this.name}Cost", _currentCost);
        PlayerPrefs.SetInt($"{this.name}Stage", _currentStage);
        PlayerPrefs.SetInt($"{this.name}Level", _level);
    }

}

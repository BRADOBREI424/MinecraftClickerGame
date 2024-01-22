using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    
    [SerializeField] private int _level;
    [SerializeField] private float[] _bonuses;
    [SerializeField] private float[] _costs;
    [SerializeField] private Sprite[] _sprites;
    private float _currentCost;
    private float _currentBonus;
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

    public void SetStats()
    {
        int CurrentStage = IdentifyStage();
        if (CurrentStage == -1)
        {
            GameObject.Find($"{this.name}/BuyUpgrade").GetComponent<Button>().enabled = false;
            GameObject.Find($"{this.name}/BuyUpgradeText").GetComponent<TMP_Text>().text = "МАКС. УРОВЕНЬ";
        }
        else
        {
            _currentCost += _costs[CurrentStage];
            _currentBonus = _bonuses[CurrentStage];
            _level += 1;
            GameObject.Find($"{this.name}/UpgradeIcon").GetComponent<Image>().sprite = _sprites[CurrentStage];
            GameObject.Find($"{this.name}/UpgradeCost").GetComponent<TMP_Text>().text = Convert.ToString(_currentCost);
            GameObject.Find($"{this.name}/UpgradeValue").GetComponent<TMP_Text>().text = Convert.ToString(_currentBonus);
            GameObject.Find($"{this.name}/UpgradeLevel").GetComponent<TMP_Text>().text = Convert.ToString(_level);
        }
    }
    private void Start() {
        SetStats();
    }
    public void Buy()
    {
        if(Money.CurrentValuue >= _currentCost)
        {
            Purchase?.Invoke(_currentCost);
            SetStats();
            SetBonus?.Invoke(_currentBonus);
        }
        else
        {
            Button BuyButton = GameObject.Find($"{this.name}/BuyUpgrade").GetComponent<Button>();
            BuyButton.animator.Play($"UpgradeCancled");
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeCosts : MonoBehaviour
{
    int[] FistCosts = {5, 25, 50, 100, 150};
    int[] ShovelCosts = {750, 900, 1050, 1200, 1350};
    int[] AxeCosts = {2500, 3000, 3500, 4000, 4500};
    int[] PickaxeCosts = {5000, 7500, 10000, 12500, 15000};

    private Dictionary<string, int[]> UpgradeCostsDictionary;

    public Dictionary<string, int[]> SetUpgradeCosts()
    {
        UpgradeCostsDictionary = new Dictionary<string, int[]>()
        {
            {"Fist", FistCosts},
            {"Shovel", ShovelCosts},
            {"Axe", AxeCosts},
            {"Pickaxe", PickaxeCosts}
        };
        return UpgradeCostsDictionary;
    }
}

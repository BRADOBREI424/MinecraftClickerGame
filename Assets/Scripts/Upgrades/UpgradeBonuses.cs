using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBonuses : MonoBehaviour
{
    float[] FistBonuses = {0.1f,0.2f,0.3f,0.4f,0.5f};
    float[] ShovelBonuses = {0.5f,0.7f,1f,1.2f,1.5f};
    float[] AxeBonuses = {1f,1.2f,1.4f,1.7f,2f};
    float[] PickaxeBonuses = {3f, 5f, 7f, 10f, 12f};
    private Dictionary<string, float[]> UpgradeBonusesDictionary;

    public Dictionary<string, float[]> SetUpgradeBonuses()
    {
        UpgradeBonusesDictionary = new Dictionary<string, float[]>()
        {
            {"Fist", FistBonuses},
            {"Shovel", ShovelBonuses},
            {"Axe", AxeBonuses},
            {"Pickaxe", PickaxeBonuses}
        };
        return UpgradeBonusesDictionary;
    }
}

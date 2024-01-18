using System.Collections.Generic;
using UnityEngine;

public class PetBonuses : MonoBehaviour
{
    float[] ChickenBonuses = {5, 10,15};
    float[] CowBonuses = {15,20,25};
    float[] ZombieBonuses = {25,30,35};
    float[] CreeperUpgrades = {35,40,45};
    float[] EndermanUpgrades = {45,50,55};
    private Dictionary<string, float[]> PetBonusesDictionary;
    public Dictionary<string,float[]> SetPetBonuses() 
    {
        PetBonusesDictionary = new Dictionary<string, float[]>()
        {
            {"Chicken", ChickenBonuses},
            {"Cow", CowBonuses},
            {"Zombie", ZombieBonuses},
            {"Creeper", CreeperUpgrades},
            {"Enderman", EndermanUpgrades}
        };
        return PetBonusesDictionary;
    }
}

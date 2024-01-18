using System.Collections.Generic;
using UnityEngine;

public class PetCosts : MonoBehaviour
{
    int[] ChickenCosts = {500, 1000,1500};
    int[] CowCosts = {1500,2000,2500};
    int[] ZombieCosts = {2500,3000,3500};
    int[] CreeperCosts = {3500,4000,4500};
    int[] EndermanCosts = {4500,5000,5500};
    private Dictionary<string, int[]> PetCostsDictionary;
    public Dictionary<string,int[]> SetPetCosts() 
    {
        PetCostsDictionary = new Dictionary<string, int[]>()
        {
            {"Chicken", ChickenCosts},
            {"Cow", CowCosts},
            {"Zombie", ZombieCosts},
            {"Creeper", CreeperCosts},
            {"Enderman", EndermanCosts}
        };
        return PetCostsDictionary;
    }
}

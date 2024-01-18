using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShop : MonoBehaviour
{
    public static Canvas Upgrades {get; set;}
    public static Canvas Pets {get; set;}
    private void Start() 
    {
        Upgrades = GameObject.Find("UpgradeMenu").GetComponent<Canvas>();
        Upgrades.gameObject.SetActive(false);
        Pets = GameObject.Find("PetsMenu").GetComponent<Canvas>();
        Pets.gameObject.SetActive(false);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private Canvas Upgrades;
    private Canvas Pets;
    private void Start() 
    {
        Upgrades = GameObject.Find("UpgradeMenu").GetComponent<Canvas>();
        Upgrades.gameObject.SetActive(false);
        Pets = GameObject.Find("PetsMenu").GetComponent<Canvas>();
        Pets.gameObject.SetActive(false);
    }

    public void OpenUpgrades()
    {
       Upgrades.gameObject.SetActive(true);
       Pets.gameObject.SetActive(false);
    }

    public void OpenPets()
    {
        Pets.gameObject.SetActive(true);
        Upgrades.gameObject.SetActive(false);
    }
}

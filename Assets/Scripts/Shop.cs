using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private Animator ClickAnimator;
    private void Start() 
    {
        this.ClickAnimator = GetComponent<Animator>();
    }

    public void OpenUpgrades()
    {
        PlayClickAnimation();
        HideShop.Upgrades.gameObject.SetActive(true);
        HideShop.Pets.gameObject.SetActive(false);
    }

    public void OpenPets()
    {
        PlayClickAnimation();
        HideShop.Pets.gameObject.SetActive(true);
        HideShop.Upgrades.gameObject.SetActive(false);
    }
    private void PlayClickAnimation()
    {
        ClickAnimator.Play("Click");
    }
}

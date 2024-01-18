using UnityEngine;

public class Exit : MonoBehaviour
{
    private Canvas UpgradeMenuLink;
    public void ExitGame()
    {
        Application.Quit();
    }
    public void ExitUpgradeMenu()
    {
        UpgradeMenuLink = GameObject.Find("UpgradeMenu").GetComponent<Canvas>();
        UpgradeMenuLink.gameObject.SetActive(false);
    }
    public void ExitPetsMenu()
    {
        UpgradeMenuLink = GameObject.Find("PetsMenu").GetComponent<Canvas>();
        UpgradeMenuLink.gameObject.SetActive(false);
    }
}

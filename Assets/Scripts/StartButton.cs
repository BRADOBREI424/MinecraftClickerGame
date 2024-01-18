using UnityEngine;

public class StartButton : MonoBehaviour
{
    private Canvas MainScence;
    private Canvas UpgradeMenu;
    private Canvas MainMenu;
    
    public void Play()
    {
        MainScence = GameObject.Find("MainScence").GetComponent<Canvas>();
        UpgradeMenu = GameObject.Find("UpgradeMenu").GetComponent<Canvas>();
        MainMenu = GameObject.Find("MainMenu").GetComponent<Canvas>();
        MainScence.gameObject.SetActive(true);
        MainMenu.gameObject.SetActive(false);
        UpgradeMenu.gameObject.SetActive(false);
    }
}

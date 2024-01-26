using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMultiple : MonoBehaviour
{
    public static Action<int> Change;
    public void ChangeCount(int count)
    {
        Change.Invoke(count);
        GameObject.Find($"{this.name}/SetUpgradeCount_1").GetComponent<Button>().image.sprite = 
        Resources.Load<Sprite>("Sprites/MenuIcons/Transperent");
        GameObject.Find($"{this.name}/SetUpgradeCount_5").GetComponent<Button>().image.sprite = 
        Resources.Load<Sprite>("Sprites/MenuIcons/Transperent");
        GameObject.Find($"{this.name}/SetUpgradeCount_10").GetComponent<Button>().image.sprite = 
        Resources.Load<Sprite>("Sprites/MenuIcons/Transperent");
        GameObject.Find($"{this.name}/SetUpgradeCount_25").GetComponent<Button>().image.sprite = 
        Resources.Load<Sprite>("Sprites/MenuIcons/Transperent");
        GameObject.Find($"{this.name}/SetUpgradeCount_50").GetComponent<Button>().image.sprite = 
        Resources.Load<Sprite>("Sprites/MenuIcons/Transperent");
        GameObject.Find($"{this.name}/SetUpgradeCount_{count}").GetComponent<Button>().image.sprite =
        Resources.Load<Sprite>("Sprites/MenuIcons/SmallButton");
    }
}

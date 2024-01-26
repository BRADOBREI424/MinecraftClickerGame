using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Orientation : MonoBehaviour
{
    private void FixedUpdate() 
    {
        if(Screen.width > Screen.height) 
        {
            GameObject.Find("MainCanvas").GetComponent<CanvasScaler>() ;
} else {
    Debug.Log("this is portrait most likely");
}
    }
}

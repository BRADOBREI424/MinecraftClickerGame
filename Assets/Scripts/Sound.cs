using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    private bool SoundPaused;
    private Button SoundButton;

    private void Start() {
        this.SoundButton = GetComponent<Button>();
    }
    private void SoundOn()
    {
        AudioListener.pause = false;
        SoundPaused = false;
        SoundButton.image.sprite = Resources.Load<Sprite>("Sprites/MenuIcons/SoundOn");
    }
    private void SoundOff()
    {
        AudioListener.pause = true;
        SoundPaused = true;
        SoundButton.image.sprite = Resources.Load<Sprite>("Sprites/MenuIcons/SoundOff");
    }
    public void Click()
    {
        if(!SoundPaused)
        {
            SoundOff();
        }
        else
        {
            SoundOn();
        }
    }
}

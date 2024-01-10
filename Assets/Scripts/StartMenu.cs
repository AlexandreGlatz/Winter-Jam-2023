using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{

    public Button sound;

    public GameObject[] toEnable;
    public GameObject[] toDisable;

    public void StartGame()
    {
        foreach (var item in toEnable)
        {
            item.SetActive(true);
        }
        foreach (var item in toDisable)
        {
            item.SetActive(false);
        }
    }

    public void ToggleSound()
    {
        if (AudioListener.volume > 0)
        {
            AudioListener.volume = 0;
            sound.image.color = Color.red;
        }
        else
        {
            AudioListener.volume = 1;
            sound.image.color = Color.white;
        }
    }

}

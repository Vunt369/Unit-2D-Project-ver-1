using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectMenu : MonoBehaviour
{
    public Button[] buttons;
    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        Console.Write(unlockedLevel);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }

    public void ResetLevel()
    {
        for (int i = 1; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
            PlayerPrefs.SetInt("ReachedIndex", 1);
            PlayerPrefs.SetInt("UnlockedLevel", 1);
            PlayerPrefs.Save();
        }
    }
    public void OpenLevel(int levelId)
    {
        switch (levelId)
        {
            case 1:
                SceneManager.LoadScene("Scene_Nhan");
                break;
            case 2:
                SceneManager.LoadScene("Scence_Vu");
                break;
            case 3:
                SceneManager.LoadScene("ThanhDong_Scene");
                break;
        }
        
    }
}

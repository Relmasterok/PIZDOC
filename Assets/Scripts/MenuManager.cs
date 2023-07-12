using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public GameObject settingsPalnel;

    public void Play()
    {
        Application.LoadLevel("Main");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void ExitMenu()
    {
        Application.LoadLevel("Menu");
    }
}

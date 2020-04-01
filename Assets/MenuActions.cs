using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuActions : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1f;
    }

    public void MENU_ACTION_GoToPage(string sceneName)
    {
        Time.timeScale = 1f;
        Application.LoadLevel(sceneName);
    }
}

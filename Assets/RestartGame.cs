using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void RestartGameAutumn()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GamePlayAutumn");
    }
    public void RestartGameSpring()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GamePlaySpring");
    }
}

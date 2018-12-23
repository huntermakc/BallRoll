using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScenController : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("MiniGame");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuCtrl : MonoBehaviour {

    public Transform UIcanvas;

	public void LoadScene(string SceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    //Enter the Street scene
    public void StartGame()
    {
        SceneManager.LoadScene("Street");
    }

    //Exit the game
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }

    //Enter the Settings
    public void OpenSetting()
    {
        PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Setting");
    }

    public void LoadLastScene()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("lastScene"));
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadMap()
    {
        PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(2);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitARGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("lastScene"));
    }

    public void EnterARGame()
    {
        PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(6);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public GameObject BossHP;

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            BossHP.SetActive(true);
        }
    }


    public void NewGame()
    {
        PlayerPrefs.SetInt("currentLevel", 1);
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("level", 1);
        PlayerPrefs.SetInt("weapon1", 1);
        PlayerPrefs.SetInt("weapon2", 1);
    }
    public void LoadNextLevel()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        var newSceneIndex = currentSceneIndex + 1;
        PlayerPrefs.SetInt("currentLevel", newSceneIndex);
        SceneManager.LoadScene(newSceneIndex);

    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadCurrentLevel()
    {
        var currentLevel = PlayerPrefs.GetInt("currentLevel");
        Time.timeScale = 1f;
        SceneManager.LoadScene(currentLevel);
    }
}

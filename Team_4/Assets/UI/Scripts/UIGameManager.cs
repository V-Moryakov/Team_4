using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameManager : MonoBehaviour
{
    public GameObject pausePanel;
    public bool pausePaneliIsOpened;
    public GameObject gameplay;
    public GameObject inventory;
    public bool inventoryIsOpened;

    public string lvl;

    private void Update()
    {
        OpenInventory();
        OpenPausePanel();
    }

    public void OpenPausePanel()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !inventory.activeSelf)
        {
            ChangePausePanelIsOpened();
            if (pausePaneliIsOpened)
            {
                Pause();
                pausePanel.SetActive(true);

            }
            else
            {
                Gameplay();
            }
        }
    }

    public void ChangePausePanelIsOpened()
    {
        pausePaneliIsOpened = !pausePaneliIsOpened;
    }
 
    void Pause()
    {
        gameplay.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Gameplay()
    {
        pausePanel.SetActive(false);
        inventory.SetActive(false);
        gameplay.SetActive(true);
        Time.timeScale = 1f;
    }

    public void OpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.I) && !pausePanel.activeSelf)
        {
            ChangeInventoryIsOpened();
            if (inventoryIsOpened)
            {
                Pause();
                inventory.SetActive(true);
            }
            else
            {
                Gameplay();
            }
        }
    }

    public void ChangeInventoryIsOpened()
    {
        inventoryIsOpened = !inventoryIsOpened;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ChooseLvl()
    {
        SceneManager.LoadScene(lvl);
    }
}

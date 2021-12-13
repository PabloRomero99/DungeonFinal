using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public static bool isGamePaused = false;

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject controlMenu;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void ControlGame() 
    {
        controlMenu.SetActive(true);
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            controlMenu.SetActive(false);
            
        }
            
    }

    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("Quit");
    }
}

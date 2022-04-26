using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //These are the variables for Resuming the game//
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;


    //This is the code for RESUME button//

     void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    //This is to go back to the Main Menu//
    public void GoToMain()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("Returning to main menu...");
    }

    //This is to go to the credits scene//
    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
        Debug.Log("Going to the credits...");
    }

    //This is to resume the game//

}

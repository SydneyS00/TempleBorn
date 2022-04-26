using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //Starts the game//
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Goes to the credit section//
    public void GetCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    //Settings button//

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string labelText = "Collect all 4 items and win your freedom!";
    public int maxItems = 3;
    public int maxAmmo = 100;
    public int maxHealth = 40;
    public bool showWinScreen = false;
    public bool showLossScreen = false;

    private int _itemsCollected = 0;
    
    public int Items
    {
        get { return _itemsCollected; }

        set { _itemsCollected = value;
            Debug.LogFormat("Items: {0}", _itemsCollected);

            if(_itemsCollected >= maxItems)
            {
                labelText = "You have found all of the items!";
                showWinScreen = true;
                Time.timeScale = 0f;
            }
            else
            {
                labelText = "Item found, only " + (maxItems - _itemsCollected) +
                    "more to go!";
            }
        }
    }

    private int _ammoCollected = 0;

    public int Bullets
    {
        get { return _ammoCollected; }
        set
        {
            _ammoCollected = value;
            Debug.LogFormat("Total Ammo: {0}", _ammoCollected);

            if(_ammoCollected >= maxAmmo)
            {
                labelText = "You have maxed out on ammo!";
                Time.timeScale = 0f;
            }
            else
            {
                labelText = "You found some ammo!";
            }

        }
    }
        

    private int _playerHP = 20;
    public int HP
    {
        get { return _playerHP; }

        set { _playerHP = value;
            if(_playerHP <= 0)
            {
                labelText = "You want another life with that?";
                showLossScreen = true;
                Time.timeScale = 0;
            }
            else
            {
                labelText = "You found a health kit!";
            }
            Debug.LogFormat("Lives: {0}", _playerHP);
        }
    }

  
    void RestartLevel()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }

    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health:" + _playerHP);
        GUI.Box(new Rect(20, 50, 150, 25), "Items Collected:" + _itemsCollected);
        //AMMO COUNTER BOX//
        GUI.Box(new Rect(20, 80, 150, 25), "Total Ammo:" + _ammoCollected);

        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50),
            labelText);


        if (showWinScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100,
                Screen.height / 2 - 50, 200, 100), "YOU WON! Click to view credits!"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        if(showLossScreen)
        {
            if(GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100),"You lose..."))
            {
                RestartLevel();
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

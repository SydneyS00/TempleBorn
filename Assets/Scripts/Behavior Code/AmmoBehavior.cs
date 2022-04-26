using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBehavior : MonoBehaviour
{
    public GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); 
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Destroy(this.transform.parent.gameObject);
            Debug.Log("Ammo collected!");
            gameManager.Bullets += 25;
        }
    }
}

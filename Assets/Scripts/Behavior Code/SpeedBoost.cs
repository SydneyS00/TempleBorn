using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float BoostVariable = 2.0f;
    public float BoostTime = 5.0f;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Destroy(this.transform.parent.gameObject);
            Debug.Log("SPEED BOOST!!");

            PlayerBehavior Player = collision.gameObject.GetComponent<PlayerBehavior>();
            Player.BoostSpeed(BoostVariable, BoostTime);

        }
    }
}

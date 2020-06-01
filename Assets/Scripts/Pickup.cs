using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public PlayerDead playerState;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            print("pickup");
            playerState.setWrench(true);
            gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finished : MonoBehaviour
{
    public PlayerDead playerState;
    private menuHandler menuHandler;

    void Start()
    {
        menuHandler = GameObject.FindGameObjectWithTag("menu").GetComponent<menuHandler>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (playerState.HasWrench)
            {
                print("You have fixed the car safely");
                menuHandler.Finish();
            }
            else
            {
                print("You don't have the tools yet to fix me");
            }
        }
    }
}

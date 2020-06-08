using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public PlayerDead playerState;
    public AudioSource pickupAudio; 
    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag.Equals("Player"))
            {
                playerState.setWrench(true);
                gameObject.SetActive(false);
                pickupAudio.Play(0);
            }
    }
}

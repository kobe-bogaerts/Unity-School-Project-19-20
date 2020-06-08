using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFinish : MonoBehaviour
{
    private menuHandler menuHandler;
    public AudioSource finishAudio;

    void Start()
    {
        menuHandler = GameObject.FindGameObjectWithTag("menu").GetComponent<menuHandler>();
        if (menuHandler.isFinished) 
            finishAudio.Play(0);             
    }
}
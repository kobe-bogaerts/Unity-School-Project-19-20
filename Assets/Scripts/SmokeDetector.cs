using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeDetector : MonoBehaviour
{
    private menuHandler menuHandler;
    public GameObject smoke;

    void Start()
    {
        menuHandler = GameObject.FindGameObjectWithTag("menu").GetComponent<menuHandler>();
        if (menuHandler.isFinished) 
            smoke.SetActive(false); 
        else
            smoke.SetActive(true);
    }
}

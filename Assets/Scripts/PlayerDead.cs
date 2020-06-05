using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDead : MonoBehaviour
{
    private bool hasWrench;
    public bool HasWrench { get { return hasWrench; } }
    public Image wrenchIcon;
    public Sprite[] sprites;
    private menuHandler menuHandler;

    void Start()
    {
        menuHandler = GameObject.FindGameObjectWithTag("menu").GetComponent<menuHandler>();
    }

    public void Kill()
    {
        print("player is dead");
        menuHandler.Dead();
    }

  public void setWrench(bool gotWrench)
    {
        this.hasWrench = gotWrench;
        if (gotWrench)
        {
            wrenchIcon.sprite = sprites[0];
        }
        else
        {
            wrenchIcon.sprite = sprites[1];
        }
    }
    
}

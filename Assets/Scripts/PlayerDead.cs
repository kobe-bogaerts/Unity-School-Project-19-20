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

  public void Kill()
    {
        print("player is dead");
        // do something 
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    private bool hasWrench;
    public bool HasWrench { get { return hasWrench; } }
  public void Kill()
    {
        print("player is dead");
        // do something 
    }

  public void setWrench(bool gotWrench)
    {
        this.hasWrench = gotWrench;
    }
    
}

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
    public AudioSource deadAudio;

    void Start()
    {
        menuHandler = GameObject.FindGameObjectWithTag("menu").GetComponent<menuHandler>();
    }

    public void Kill()
    {
        deadAudio.Play(0);
        StartCoroutine("EndSound");
        print("player is dead");
        
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

    IEnumerator EndSound()
    {
        yield return new WaitForSeconds(1.5f);
        if(menuHandler != null)
            menuHandler.Dead();
    }
    
}

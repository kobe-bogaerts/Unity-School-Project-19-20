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
    private bool isDead = false;

    void Start()
    {
        menuHandler = GameObject.FindGameObjectWithTag("menu").GetComponent<menuHandler>();
    }

    public void Kill()
    {
        if (!isDead)
        {
            deadAudio.Play(0);
            StartCoroutine("EndSound");
            isDead = true;
        }
        
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
        while (Camera.main.fieldOfView >= 1)
        {
            Camera.main.fieldOfView -= 1;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(0.5f);
        if (menuHandler != null)
            menuHandler.Dead();
    }
    
}

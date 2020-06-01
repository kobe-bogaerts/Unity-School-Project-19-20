using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuHandler : MonoBehaviour
{
    public Text title;
    public Text actionButtonText;
    public Canvas canvas;
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);    
    }

    public void Quit()
    {
        Application.Quit();
    }
    
    public void Dead()
    {
        title.text = "You died!";
        actionButtonText.text = "Restart Game";
        SceneManager.LoadScene(0);
        canvas.enabled = true;
    }

    public void Finish()
    {
        title.text = "You Won!";
        actionButtonText.text = "Restart Game";
        SceneManager.LoadScene(0);
        canvas.enabled = true;
    }

    public void actionButtonClick()
    {
        StartCoroutine("Fade");
    }

    IEnumerator Fade()
    {
        while(Camera.main.fieldOfView > 1)
        {
            Camera.main.fieldOfView -= 5;
            yield return new WaitForSeconds(0.1f);
        }
        canvas.enabled = false;
        SceneManager.LoadScene(1);
    }

}

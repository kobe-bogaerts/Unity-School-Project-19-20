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
        if (GameObject.FindGameObjectsWithTag("menu").Length > 1)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);    
    }

    public void Quit()
    {
        if (Application.isEditor)
            UnityEditor.EditorApplication.isPlaying = false;
        else
            Application.Quit();
    }
    
    public void Dead()
    {
        title.text = "You died!";
        actionButtonText.text = "Restart Game";
        loadMenu();
    }

    public void Finish()
    {
        title.text = "You have fixed the car safely. Drive off in to the sunset!";
        actionButtonText.text = "Restart Game";
        loadMenu();
    }

    private void loadMenu()
    {
        SceneManager.LoadScene(0);
        canvas.enabled = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void actionButtonClick()
    {
        StartCoroutine("Fade");
    }

    IEnumerator Fade()
    {
        while(Camera.main.fieldOfView >= 1)
        {
            Camera.main.fieldOfView -= 1;
            yield return new WaitForSeconds(0.02f);
        }
        canvas.enabled = false;
        SceneManager.LoadScene(1);
    }

}

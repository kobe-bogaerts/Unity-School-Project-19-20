using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletMode : MonoBehaviour
{
    public Image image;
    public Sprite fullMode;
    public Sprite singleMode;

    public void ToggleMode()
    {
        if(image.sprite.name == fullMode.name)
        {
            image.sprite = singleMode;
        }
        else
        {
            image.sprite = fullMode;
        }
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerClick : MonoBehaviour
{

    public Flashlight_PRO flashlight;
    private bool isOn = false;
    private float time = 0;

    void Start()
    {
        flashlight.Change_Intensivity(100f);
        flashlight.Enable_Particles(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0) && Time.time > time + 0.3f)
        {
            isOn = !isOn;
            flashlight.Enable_Particles(false);
            flashlight.Switch();
            time = Time.time;
        }
    }
}

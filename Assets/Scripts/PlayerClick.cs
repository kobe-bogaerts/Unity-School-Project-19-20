using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerClick : MonoBehaviour
{

    public Flashlight_PRO flashlight;
    public float flashLightChargeIncrements = 0.05f;
    public float flashLightChargeDecrements = 0.15f;
    public float flashLightChargeDecreseTime = 1f;
    public Slider batterySlider;
    private bool isOn = false;
    private float clickRate = 0;
    private float timer = 0;

    void Start()
    {
        flashlight.Change_Intensivity(100f);
        flashlight.Enable_Particles(false);
        batterySlider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0) && Time.time > clickRate + 0.3f && batterySlider.value > 0)
        {
            isOn = !isOn;
            flashlight.Enable_Particles(false);
            flashlight.Switch();
            clickRate = Time.time;
        }

        if (timer > flashLightChargeDecreseTime)
        {
            if(isOn)
                batterySlider.value -= flashLightChargeDecrements;
            else
                batterySlider.value += flashLightChargeIncrements;
            timer = 0;
        }
        timer += Time.deltaTime;

        if (batterySlider.value == 0 && isOn)
        {
            isOn = false;
            flashlight.Switch();
        }
    }
}

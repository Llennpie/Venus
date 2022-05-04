using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerMeterHandler : MonoBehaviour
{
    // 200 = 0
    // 196 = 4 = 98% -> -88.2
    // 191 = 9 = 95.5% -> -85.95
    // 181 = 19 = 90.5% -> -81.45
    bool visible = false;
    bool wasVisible = false;
    float empTime = 0;
    static readonly float targetY = -30;
    float targetYEmp = targetY * 1.75f;
    float pct1 = 181f/200f;
    float pct2 = 191f/200f;
    float pct3 = 196f/200f;
    [HideInInspector] public short hp = 2176;
    [SerializeField] RawImage hpMeter;

    void Update()
    {
        if (hp >= 2048)
        {
            hpMeter.texture = ROMTextureLoader.gTextures["hud_power_eight"];
            visible = false;
        }
        else if (hp>=1792 && hp < 2048)
        {
            hpMeter.texture = ROMTextureLoader.gTextures["hud_power_seven"];
            visible = true;
        }
        else if (hp >= 1536 && hp < 1792)
        {
            hpMeter.texture = ROMTextureLoader.gTextures["hud_power_six"];
            visible = true;
        }
        else if (hp >= 1280 && hp < 1536)
        {
            hpMeter.texture = ROMTextureLoader.gTextures["hud_power_five"];
            visible = true;
        }
        else if (hp >= 1024 && hp < 1280)
        {
            hpMeter.texture = ROMTextureLoader.gTextures["hud_power_four"];
            visible = true;
        }
        else if (hp >= 768 && hp < 1024)
        {
            hpMeter.texture = ROMTextureLoader.gTextures["hud_power_three"];
            visible = true;
        }
        else if (hp >= 512 && hp < 768)
        {
            hpMeter.texture = ROMTextureLoader.gTextures["hud_power_two"];
            visible = true;
        }
        else if (hp >= 256 && hp < 512)
        {
            hpMeter.texture = ROMTextureLoader.gTextures["hud_power_one"];
            visible = true;
        }
        else if (hp >= 0 && hp < 256)
        {
            hpMeter.enabled = false;
            visible = true;
        }
    }

    void FixedUpdate()
    {
        if (visible && !wasVisible)
        {
            empTime = 45f * Time.fixedDeltaTime;
        }

        var rt = GetComponent<RectTransform>();
        int speed = 0;
        if (!visible && rt.anchoredPosition.y < 0)
        {
            speed = 20;
        }
        else if (visible && empTime > 0)
        {
            rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, targetYEmp);
            empTime -= Time.fixedDeltaTime;
        }
        else if (visible && empTime <= 0 && rt.anchoredPosition.y < targetY)
        {
            var prog = Mathf.InverseLerp(targetYEmp, targetY, rt.anchoredPosition.y);
            speed = 2;
            if (prog > pct1)
            {
                speed = 3;
            }
            if (prog > pct2)
            {
                speed = 2;
            }
            if (prog > pct3)
            {
                speed = 1;
            }
        }
        else
        {
            return;
        }
        rt.anchoredPosition += new Vector2(0, speed);
        wasVisible = visible;
    }
}

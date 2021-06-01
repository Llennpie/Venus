using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LibSM64;

public class ColorCode : MonoBehaviour
{
    private SM64Mario mario;

    // no shading light colors, due to our reliance on unity's lighting and not sm64's lighting
    public Color32[] customColors = {
        new Color32(255, 0, 0, 255),        // Shirt/Cap
        new Color32(0, 0, 255, 255),        // Overalls
        new Color32(255, 255, 255, 255),    // Gloves
        new Color32(127, 28, 14, 255),      // Shoes
        new Color32(254, 193, 121, 255),    // Skin
        new Color32(115, 6, 0, 255)         // Hair
    };
    Color[] colors;

    // Start is called before the first frame update
    void Start()
    {
        colors = new Color[3072];
        mario = GetComponent<SM64Mario>();
    }

    void Update()
    {
        // update colors every frame (for now)
        // this will let us update customColors in realtime
        // will change this in the future if i make a cc editor
        UpdateColors();
        mario.marioMesh.colors = colors;
    }

    void UpdateColors()
    {
        for(int i = 0; i < 495; i++) {
            colors[i] = customColors[1];
        }
        for(int i = 495; i < 585; i++) {
            colors[i] = customColors[0];
        }
        for(int i = 585; i < 930; i++) {
            colors[i] = customColors[4];
        }
        for(int i = 930; i < 1059; i++) {
            colors[i] = customColors[0];
        }
        for(int i = 1059; i < 1140; i++) {
            colors[i] = customColors[5];
        }
        for(int i = 1140; i < 1332; i++) {
            colors[i] = customColors[0];
        }
        for(int i = 1332; i < 1470; i++) {
            colors[i] = customColors[2];
        }
        for(int i = 1470; i < 1662; i++) {
            colors[i] = customColors[0];
        }
        for(int i = 1662; i < 1800; i++) {
            colors[i] = customColors[2];
        }
        for(int i = 1800; i < 1950; i++) {
            colors[i] = customColors[1];
        }
        for(int i = 1950; i < 2028; i++) {
            colors[i] = customColors[3];
        }
        for(int i = 2028; i < 2178; i++) {
            colors[i] = customColors[1];
        }
        for(int i = 2178; i < 2256; i++) {
            colors[i] = customColors[3];
        }
    }
}
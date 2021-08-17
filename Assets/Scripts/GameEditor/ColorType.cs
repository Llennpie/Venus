using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorType : MonoBehaviour
{
    Color32 color;
    public enum BodyColorType {
        Shirt, Pants, Gloves, Shoes, Skin, Hair
    }
    public BodyColorType colorType;
    public Text hexText;
    public ColorCode mario;
    private InputField inputField;
    
    // Start is called before the first frame update
    void Start()
    {
        inputField = GetComponentInChildren<InputField>();

        if (colorType == BodyColorType.Shirt) {
            color = mario.customColors[0];
        } else if (colorType == BodyColorType.Pants) {
            color = mario.customColors[1];
        } else if (colorType == BodyColorType.Gloves) {
            color = mario.customColors[2];
        } else if (colorType == BodyColorType.Shoes) {
            color = mario.customColors[3];
        } else if (colorType == BodyColorType.Skin) {
            color = mario.customColors[4];
        } else if (colorType == BodyColorType.Hair) {
            color = mario.customColors[5];
        }

        GetComponent<Image>().color = color;
        hexText.color = color;

        string hex = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
        inputField.text = hex;
    }

    public void UpdateColor ()
    {
        if (inputField.text.Length < 6) {
            inputField.text = "000000";
        }

        byte r = byte.Parse(inputField.text.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(inputField.text.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(inputField.text.Substring(4,2), System.Globalization.NumberStyles.HexNumber);

        // 255 is the alpha. this really doesn't need to be configurable
        color = new Color32(r, g, b, 255);

        if (colorType == BodyColorType.Shirt) {
            mario.customColors[0] = color;
        } else if (colorType == BodyColorType.Pants) {
            mario.customColors[1] = color;
        } else if (colorType == BodyColorType.Gloves) {
            mario.customColors[2] = color;
        } else if (colorType == BodyColorType.Shoes) {
            mario.customColors[3] = color;
        } else if (colorType == BodyColorType.Skin) {
            mario.customColors[4] = color;
        } else if (colorType == BodyColorType.Hair) {
            mario.customColors[5] = color;
        }

        mario.UpdateColors();

        GetComponent<Image>().color = color;
        hexText.color = color;
        inputField.text = inputField.text.ToUpper();
    }
}

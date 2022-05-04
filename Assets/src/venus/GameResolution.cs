using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameResolution : MonoBehaviour
{
    [SerializeField] Toggle fullscreenToggle;
    Resolution[] resolutions;
    Dropdown dropdown;

    void Start()
    {
        resolutions = Screen.resolutions.Where(resolution => resolution.refreshRate == 60).ToArray();
        
        // load resolutions
        fullscreenToggle.isOn = PlayerPrefs.GetInt("Fullscreen", Screen.fullScreen ? 1 : 0) > 0;
        Screen.SetResolution(PlayerPrefs.GetInt("ResolutionWidth", Screen.currentResolution.width), PlayerPrefs.GetInt("ResolutionHeight", Screen.currentResolution.height), fullscreenToggle.isOn);

        dropdown = GetComponent<Dropdown>();
        dropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResIndex = i;
            }
        }
        dropdown.AddOptions(options);
        dropdown.value = currentResIndex;
        dropdown.RefreshShownValue();
    }

    public void Apply() {
        UpdateResolution();
        SetFullscreen();
    }

    void UpdateResolution()
    {
        UnityEngine.Resolution selectedResolution = resolutions[dropdown.value];
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen);

        PlayerPrefs.SetInt("ResolutionWidth", selectedResolution.width);
        PlayerPrefs.SetInt("ResolutionHeight", selectedResolution.height);
    }

    void SetFullscreen()
    {
        Screen.fullScreen = fullscreenToggle.isOn;
        PlayerPrefs.SetInt("Fullscreen", fullscreenToggle.isOn ? 1 : 0);
    }
}

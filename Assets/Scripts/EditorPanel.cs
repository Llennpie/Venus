using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditorPanel : MonoBehaviour
{
    public GameObject editorPanel;
    public Button firstSelected;

    // Start is called before the first frame update
    void Start()
    {
        // close when the game is started, in case we accidentally left it open
        editorPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Menu")) {
            ToggleOpenPanel();
        }
    }

    public void ToggleOpenPanel () {
        editorPanel.SetActive(!editorPanel.activeSelf);
        Time.timeScale = editorPanel.activeSelf ? 0 : 1;
        firstSelected.Select();
    }
}

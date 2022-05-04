using UnityEngine;
using UnityEngine.UI;

public class EditorPanel : MonoBehaviour
{
    [SerializeField] GameObject editorPanel;
    [SerializeField] Button firstSelected;

    [SerializeField] Material stage;

    void Start()
    {
        editorPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Menu")) {
            ToggleOpenPanel();
        }
    }

    public void ToggleOpenPanel() {
        editorPanel.SetActive(!editorPanel.activeSelf);
        Time.timeScale = editorPanel.activeSelf ? 0 : 1;
        firstSelected.Select();
    }

    public void SetStageColor(string color)
    {
        switch (color)
        {
            case "red":
                stage.color = Color.red;
                break;
            case "green":
                stage.color = Color.green;
                break;
            case "blue":
                stage.color = Color.blue;
                break;
            case "pink":
                stage.color = new Color(1, 0, 1);
                break;
        }
    }
    void OnApplicationQuit()
    {
        stage.color = Color.green;
    }
}

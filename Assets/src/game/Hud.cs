using UnityEngine;
using UnityEngine.SceneManagement;

public class Hud : MonoBehaviour
{
    [SerializeField] GameObject coinCount;

    public static Canvas HUD;

    void Awake()
    {
        HUD = GetComponent<Canvas>();
        HUD.enabled = false;

        if (SceneManager.GetActiveScene().buildIndex < 2)
        {
            coinCount.SetActive(false);
        }
    }

    public static void HideHUD(bool value)
    {
        HUD.enabled = !value;
    }
}

using UnityEngine;

public class HideHudToggle : MonoBehaviour
{
    public void HideHud(bool value)
    {
        Hud.HideHUD(value);
    }
}

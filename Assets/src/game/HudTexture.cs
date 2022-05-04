using UnityEngine;
using UnityEngine.UI;

public class HudTexture : MonoBehaviour
{
    [SerializeField] string texture = "hud_";
    void Start()
    {
        GetComponent<RawImage>().texture = ROMTextureLoader.gTextures[texture];
    }
}

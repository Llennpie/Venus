using UnityEngine;

public class GenericTexture : MonoBehaviour
{
    [SerializeField] Material[] materials;
    [SerializeField] string[] textures;

    void Start()
    {
        for(int i = 0; i < materials.Length; i++)
        {
            materials[i].mainTexture = ROMTextureLoader.gTextures[textures[i]];
            materials[i].SetTexture("_EmissionMap", ROMTextureLoader.gTextures[textures[i]]);
        }
    }
}

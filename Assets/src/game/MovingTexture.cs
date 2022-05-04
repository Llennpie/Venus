using UnityEngine;

public class MovingTexture : MonoBehaviour
{
    [SerializeField] Material material;
    [SerializeField] float xSpeed;
    [SerializeField] float ySpeed;

    // seems to just lag the game, even on fixed update
    void FixedUpdate()
    {
        float x = Time.time * xSpeed;
        float y = Time.time * ySpeed;
        material.mainTextureOffset = new Vector2(y, x);
    }

    void OnApplicationQuit()
    {
        material.mainTextureOffset = Vector2.zero;
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class BhvWarpPipe : MonoBehaviour
{
    [SerializeField] string destination;
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        GetComponent<AudioSource>().Play();
        Invoke("Warp", 0.75f);
    }

    void Warp()
    {
        SceneManager.LoadScene(destination);
    }
}

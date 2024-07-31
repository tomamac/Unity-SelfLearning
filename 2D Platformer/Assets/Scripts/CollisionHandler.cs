using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (other.gameObject.tag == "Respawn")
        {
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}

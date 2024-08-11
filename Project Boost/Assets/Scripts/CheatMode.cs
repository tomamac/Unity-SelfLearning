using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatMode : MonoBehaviour
{
    public bool CheatEnabled = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;
            int lastSceneIndex = SceneManager.sceneCountInBuildSettings - 1;

            if (currentSceneIndex == lastSceneIndex)
            {
                nextSceneIndex = 0;
            }
            SceneManager.LoadScene(nextSceneIndex);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            CheatEnabled = !CheatEnabled;
            Debug.Log("Cheat mode : " + CheatEnabled);
        }
    }
}

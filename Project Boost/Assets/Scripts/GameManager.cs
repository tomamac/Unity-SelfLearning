using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;

    public bool CheatEnabled = false;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public enum GameState
    {
        Playing,
        Transition
    }

    public void SetGameState(GameState NewState)
    {
        State = NewState;

        switch (NewState)
        {
            case GameState.Playing:
                break;
            case GameState.Transition:
                break;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Instance.LoadNextScene();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Instance.CheatEnabled = !Instance.CheatEnabled;
            Debug.Log("Cheat mode : " + CheatEnabled);
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
            Debug.Log("Game closed");
        }
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        int lastSceneIndex = SceneManager.sceneCountInBuildSettings - 1;

        if (currentSceneIndex == lastSceneIndex)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
        Instance.SetGameState(GameState.Playing);
    }

    public void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        Instance.SetGameState(GameState.Playing);
    }
}

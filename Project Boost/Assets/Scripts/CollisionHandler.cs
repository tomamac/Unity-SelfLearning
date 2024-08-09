using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    AudioSource audioSrc;

    bool isTransitioning = false;

    [SerializeField] AudioClip Crash;
    [SerializeField] AudioClip Finish;
    [SerializeField] float delayTime = 1f;


    void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning) { return; }
        switch (other.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                StartLevelSequence("NextLevel");
                break;
            default:
                StartLevelSequence("ReloadLevel");
                break;
        }
    }

    void StartLevelSequence(string function)
    {
        isTransitioning = true;
        audioSrc.Stop();
        switch (function)
        {
            case "NextLevel":
                audioSrc.PlayOneShot(Finish);
                break;
            case "ReloadLevel":
                audioSrc.PlayOneShot(Crash);
                break;
        }
        GetComponent<Movement>().enabled = false;
        Invoke(function, delayTime);
    }
    void NextLevel()
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

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
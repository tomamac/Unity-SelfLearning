using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    AudioSource audioSrc;

    [SerializeField] AudioClip Crash;
    [SerializeField] AudioClip Finish;

    [SerializeField] ParticleSystem SuccessParticles;
    [SerializeField] ParticleSystem CrashParticles;

    [SerializeField] float delayTime = 1f;

    void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (GameManager.Instance.State == GameManager.GameState.Transition || GameManager.Instance.CheatEnabled) { return; }
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
        GameManager.Instance.SetGameState(GameManager.GameState.Transition);
        audioSrc.Stop();
        switch (function)
        {
            case "NextLevel":
                audioSrc.PlayOneShot(Finish);
                SuccessParticles.Play();
                break;
            case "ReloadLevel":
                audioSrc.PlayOneShot(Crash);
                CrashParticles.Play();
                break;
        }
        Invoke(function, delayTime);
    }

    void NextLevel()
    {
        GameManager.Instance.LoadNextScene();
    }

    void ReloadLevel()
    {
        GameManager.Instance.ReloadScene();
    }
}

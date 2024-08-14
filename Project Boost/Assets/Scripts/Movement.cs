using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSrc;

    [SerializeField] AudioClip Thrust;
    [SerializeField] ParticleSystem MainBooster;
    [SerializeField] ParticleSystem LeftBooster;
    [SerializeField] ParticleSystem RightBooster;

    [SerializeField] float rotationSpeed = 100f;
    [SerializeField][Range(1000, 5000)] float thrustSpeed = 1000;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSrc = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.State == GameManager.GameState.Playing)
        {
            ProcessThrust();
            ProcessRotation();
        }
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotating();
        }
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    private void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * thrustSpeed * Time.fixedDeltaTime);
        if (!audioSrc.isPlaying)
        {
            audioSrc.PlayOneShot(Thrust);
        }
        if (!MainBooster.isPlaying)
        {
            MainBooster.Play();
        }
    }

    private void StopThrusting()
    {
        audioSrc.Stop();
        MainBooster.Stop();
    }

    private void RotateLeft()
    {
        rotate(Vector3.forward);
        if (!RightBooster.isPlaying)
        {
            RightBooster.Play();
        }
    }

    private void RotateRight()
    {
        rotate(-Vector3.forward);
        if (!LeftBooster.isPlaying)
        {
            LeftBooster.Play();
        }
    }

    private void StopRotating()
    {
        RightBooster.Stop();
        LeftBooster.Stop();
    }

    private void rotate(Vector3 rotateDirection)
    {
        /*  Different type of rotations
                Transform: use transform if physics are not nessesary
            vvvv for rigidbodies vvvv
                AddTorque: similar to AddForce but for rotation
                Rotation: similar to transform.rotation but physics based
                angularVelocity: continuous rotation at fixed speed e.g. obstacles, fan blades; */
        rb.rotation *= Quaternion.Euler(rotateDirection * rotationSpeed * Time.fixedDeltaTime);
    }
}

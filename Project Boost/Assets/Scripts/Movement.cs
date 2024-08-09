using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSrc;

    bool isAlive;

    [SerializeField] AudioClip Thrust;
    [SerializeField] float rotationSpeed = 100f;
    [SerializeField][Range(1000, 5000)] float thrustSpeed = 1000;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        /* Differences between GetKey and GetAxis
            GetKey = true and false, GetAxis = -1,0,1
            
            Different type of rotations
            Transform: use transform if physics are not nessesary
            vvvv for rigidbodies vvvv
            AddTorque: similar to AddForce but for rotation
            Rotation: similar to transform.rotation but physics based
            angularVelocity: continuous rotation at fixed speed e.g. obstacles, fan blades;
            */

        if (Input.GetKey(KeyCode.A))
        {
            rotate(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rotate(-Vector3.forward);
        }
    }

    private void rotate(Vector3 rotateDirection)
    {
        rb.rotation *= Quaternion.Euler(rotateDirection * rotationSpeed * Time.fixedDeltaTime);
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrustSpeed * Time.fixedDeltaTime);
            if (!audioSrc.isPlaying)
            {
                audioSrc.PlayOneShot(Thrust);
            }
        }
        else
        {
            audioSrc.Stop();
        }
    }
}

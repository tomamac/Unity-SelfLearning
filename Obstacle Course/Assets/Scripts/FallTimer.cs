using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTimer : MonoBehaviour
{
    [SerializeField]float timeToWait = 3f;
    MeshRenderer renderer;
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        rigidbody = GetComponent<Rigidbody>();
        renderer.enabled = false;
        rigidbody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log((int)Time.time);
        if(Time.time >= timeToWait)
        {
            renderer.enabled = true;
            rigidbody.useGravity = true;
        }
    }
}

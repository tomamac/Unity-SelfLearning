using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTimer : MonoBehaviour
{
    [SerializeField]float timeToWait = 3f;
    MeshRenderer Mrenderer;
    Rigidbody rigbod;
    // Start is called before the first frame update
    void Start()
    {
        Mrenderer = GetComponent<MeshRenderer>();
        rigbod = GetComponent<Rigidbody>();
        Mrenderer.enabled = false;
        rigbod.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log((int)Time.time);
        if(Time.time >= timeToWait)
        {
            Mrenderer.enabled = true;
            rigbod.useGravity = true;
        }
    }
}

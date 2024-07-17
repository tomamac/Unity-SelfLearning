using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float xVal = 0f;
    [SerializeField] float yVal = 0f;
    [SerializeField] float zVal = 0f;
    void Update()
    {
        transform.Rotate(xVal, yVal, zVal);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    [SerializeField]float playerSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float xVal = Input.GetAxis("Horizontal")*Time.deltaTime*playerSpeed;
        float zVal = Input.GetAxis("Vertical")*Time.deltaTime*playerSpeed;
        transform.Translate(xVal, 0, zVal);
    }
}

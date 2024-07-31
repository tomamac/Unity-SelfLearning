using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    [SerializeField] float playerSpeed = 500f;
    Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float xVal = Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;
        float zVal = Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed;
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        // transform.Translate(xVal, 0, zVal);

    }
    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody>().velocity = movement * playerSpeed * Time.deltaTime;
    }
}

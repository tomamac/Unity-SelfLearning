using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        // Debug.Log("Bumped into a wall");
        //Default unity colors = Color.<color>
        //Custom = new Color(r,g,b<,a optional>) [Calling unity's color constructor]
        //RGB range in unity is 0 to 1 [eg. 0.3f]
        if (other.gameObject.tag == "Player")
        {
            //Access object's component with GetComponent<componentName>()
            GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0);
            gameObject.tag = "Hit";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour
{
    public int clicksToPop = 3;
    // Start is called before the first frame update

    //called when clicked on game object
    private void OnMouseDown()
    {
        clicksToPop--;

        //increase the balloon scale
        transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);

        //when clicks reaches 0 or less the balloon pops (destroyed)
        if (clicksToPop <= 0)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

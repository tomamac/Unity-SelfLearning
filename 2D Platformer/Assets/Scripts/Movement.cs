using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 40f;
    [SerializeField] float jumpForce = 10;
    float horizontalInput = 0f;
    bool jumpInput;
    Rigidbody2D player;

    //Awake is called before "Start" and is called even script component is disabled
    void Awake()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal") * moveSpeed;
        if(Input.GetKeyDown("space")){
            jumpInput = true;
        }
    }

    //FixedUpdate intervals are consistent
    //used for updates such as physics objects (rigidbody)
    void FixedUpdate()
    {
        Vector2 newVelocity = new Vector2(horizontalInput * Time.fixedDeltaTime * 10f, player.velocity.y);
        player.velocity = newVelocity;
        if(jumpInput){
            player.velocity = new Vector2(player.velocity.x,jumpForce);
            jumpInput = false;
        }
    }
}

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool jumping;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update() 
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        // flip character
        if (horizontalInput > 0.01f) 
        {
            transform.localScale = Vector3.one;
        } else if (horizontalInput < -0.01f) 
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKey(KeyCode.Space) && !jumping)
        {
            Jump();
        }

        // Set anim parameter
        anim.SetBool("Walking", horizontalInput != 0);
        anim.SetBool("Jumping", jumping);
    }

    private void Jump() 
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        jumping = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") 
        {
            jumping = false;
        }
    }
}

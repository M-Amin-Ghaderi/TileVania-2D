using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float climbingSpeed = 5f;

    private Rigidbody2D rb2d;
    private Animator anim;
    private CapsuleCollider2D myCapsuleCollider2D;
    private BoxCollider2D myFeetCollider;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        myCapsuleCollider2D = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent <BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Climbing();
        Jump();
        FlipSprite();
    }
    public void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, rb2d.velocity.y);
        rb2d.velocity = playerVelocity;
        bool playerHasHorizontalSpeed = Mathf.Abs(rb2d.velocity.x) > math.EPSILON;
        anim.SetBool("Running", playerHasHorizontalSpeed);

    }

    public void Climbing()
    {
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            anim.SetBool("Climbing", false);
            rb2d.gravityScale = 1f;
            return;
        }
        float controlThrow = CrossPlatformInputManager.GetAxis("Vertical");
        rb2d.gravityScale = 0;
        Vector2 climbingVelocity = new Vector2(rb2d.velocity.x, controlThrow * climbingSpeed);
        rb2d.velocity = climbingVelocity;
        bool playerHasHorizontalSpeed = Mathf.Abs(rb2d.velocity.y) > math.EPSILON;
        anim.SetBool("Climbing", playerHasHorizontalSpeed);
    }

    public void Jump()
    {
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Vector2 jumpingVeclocity = new Vector2(0f, jumpForce);
            rb2d.velocity += jumpingVeclocity;
        }
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb2d.velocity.x) > math.EPSILON;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb2d.velocity.x), 1f);
        }
    }
}

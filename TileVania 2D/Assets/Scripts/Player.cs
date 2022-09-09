using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpForce = 5f;

    private Rigidbody2D rb2d;
    private Animator anim;
    private Collider2D mycollider2D;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        mycollider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
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

    public void Jump()
    {
        if (!mycollider2D.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }
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

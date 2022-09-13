using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    private Rigidbody2D enemyRb2D;
    private BoxCollider2D enemyEdgeDetectorCollider;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb2D = GetComponent<Rigidbody2D>();
        enemyEdgeDetectorCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x > 0)
        {
            enemyRb2D.velocity = new Vector2(moveSpeed, 0);
        }
        else
        {
            enemyRb2D.velocity = new Vector2(-moveSpeed, 0);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(enemyRb2D.velocity.x)), 1f);
    }
}

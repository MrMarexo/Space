using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    Rigidbody2D rb;
    float dirX;
    float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -2.45f, 2.45f), transform.position.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);
    }
}

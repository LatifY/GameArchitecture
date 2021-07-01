using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameArchPlayer : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private float playerSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private int maxJump;
    private int jumpCounter;
    private bool grounded = true;
    

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

	private void Awake()
	{
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        transform.Translate(xAxis * playerSpeed * Time.deltaTime, 0f, 0f);
		if (xAxis < 0)
		{
            spriteRenderer.flipX = true;
		}
		else if(xAxis > 0)
		{
            spriteRenderer.flipX = false;
        }

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && grounded)
        {
            jumpCounter++;
			if (jumpCounter >= maxJump)
			{
                jumpCounter = 0;
                grounded = false;
            }
            rb.AddForce(new Vector2(0, jumpSpeed),ForceMode2D.Impulse);
        }
    }

    public void touchGround()
	{
        print("touched the ground");
        grounded = true;
	}

    
}

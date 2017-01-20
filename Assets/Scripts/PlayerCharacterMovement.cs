using UnityEngine;
using System.Collections;

public class PlayerCharacterMovement : MonoBehaviour
{
	public float movementForce;
	public float jumpForce;
	public Transform guyCollisionChecker1;
	public Transform guyCollisionChecker2;
	public LayerMask whatIsGround;

	float movementDirection;
	Rigidbody2D rigidbody2d;
	Vector2 forceVector;
	bool isOnGround;

	void Start()
	{
		rigidbody2d = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		movementDirection = Input.GetAxisRaw("Horizontal");
	}

	void FixedUpdate()
	{
		isOnGround = Physics2D.OverlapArea(guyCollisionChecker1.position, guyCollisionChecker2.position, whatIsGround);
		forceVector = new Vector2(movementDirection * movementForce, rigidbody2d.velocity.y);
		rigidbody2d.velocity = forceVector;
		if (Input.GetButton("Jump") && isOnGround)
		{
			rigidbody2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
		}
	}
}

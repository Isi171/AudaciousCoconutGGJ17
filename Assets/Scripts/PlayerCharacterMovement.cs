using UnityEngine;
using System.Collections;

public class PlayerCharacterMovement : MonoBehaviour
{
	public float movementForce;
	public float jumpForce;
	public Transform guyCollisionChecker1;
	public Transform guyCollisionChecker2;
	public LayerMask whatIsGround;
	public LayerMask whatIsWater;
	public BoxCollider2D onGroundBoxCollider;
	public BoxCollider2D inWaterBoxCollider;

	private float movementDirection;
	private Rigidbody2D rigidbody2d;
	private bool isOnGround;
	private bool isInWater;

	private void Start()
	{
		rigidbody2d = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		movementDirection = Input.GetAxisRaw("Horizontal");
	}

	private void FixedUpdate()
	{
		//Horizontal movement
		isInWater = Physics2D.OverlapArea(guyCollisionChecker1.position, guyCollisionChecker2.position, whatIsWater);
		if (!isInWater)
		{
			ActivateGroundCollider();
			rigidbody2d.velocity = new Vector2(movementDirection * movementForce, rigidbody2d.velocity.y);
		}
		else
		{
			ActivateWaterCollider();
		}

		//Jump
		isOnGround = Physics2D.OverlapArea(guyCollisionChecker1.position, guyCollisionChecker2.position, whatIsGround);
		if (isOnGround && Input.GetButton("Jump"))
		{
			rigidbody2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
		}
	}

	private void ActivateGroundCollider()
	{
		onGroundBoxCollider.enabled = true;
		inWaterBoxCollider.enabled = false;
	}

	private void ActivateWaterCollider()
	{
		onGroundBoxCollider.enabled = false;
		inWaterBoxCollider.enabled = true;
	}
}

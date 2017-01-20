//using UnityEngine;
//using System.Collections;
//
//public class Rideable : MonoBehaviour
//{
//	public bool canRide = true;
//	public ArrayList boundCharacter = new ArrayList();
//
//	void OnCollisionEnter2D(Collision2D collision2d)
//	{
//		GameObject other = collision2d.gameObject;
//		Vector3 normal = collision2d.contacts[0].normal;
//		bool isInverse = UtilityFunctions.NormalIsTheInverseOfGravity(normal, other);
//
//		//when robot is on top of patroller
//		if (isInverse && !GetComponent<GravityChangeable>().rotating && canRide)
//		{
//			if (!boundCharacter.Contains(other) && other.transform.parent == null && !other.GetComponent<Patroller>())
//			{
//				BindCharacter(other);
//			}
//		}
//	}
//
//	void OnCollisionStay2D(Collision2D coll)
//	{
//		GameObject other = coll.gameObject;
//		Vector3 normal = coll.contacts[0].normal;
//
//		if (normal == GetComponent<Patroller>().GetDir())
//		{
//			if (boundCharacter.Contains(other))
//			{
//				UnbindCharacter(other);
//			}
//		}
//	}
//
//
//	void OnCollisionExit2D(Collision2D collision)
//	{
//		GameObject other = collision.gameObject;
//		if (boundCharacter.Contains(other))
//		{
//			if (other.transform.parent.gameObject.Equals(gameObject))
//			{
//				UnbindCharacter(other);
//			}
//		}
//	}
//
//	void BindCharacter(GameObject other)
//	{
//		boundCharacter.Add(other);
//		other.transform.parent = transform;
//	}
//
//	void UnbindCharacter(GameObject other)
//	{
//		boundCharacter.Remove(other);
//		other.GetComponent<MovementEngine>().addedForce = Vector2.zero;
//		if (other.GetComponent<RobotMovement>())
//			other.GetComponent<RobotMovement>().canJump = true; 
//		other.transform.parent = null;
//	}
//
//	public void MoveBounded(Vector2 offset)
//	{
//		foreach (GameObject go in boundCharacter)
//		{
//			go.GetComponent<MovementEngine>().addedForce = offset;
//			//go.GetComponent<Rigidbody2D>().velocity += rigidbody.velocity;         
//		}
//	}
//
//	public void OnDeath()
//	{
//		foreach (PatrollerStopper ps in GetComponentsInChildren<PatrollerStopper>())
//			ps.OnDeath(true);
//
//		foreach (GameObject other in boundCharacter)
//		{        
//			other.GetComponent<MovementEngine>().addedForce = Vector2.zero;
//			other.GetComponent<GravityChangeable>().active = true;
//			other.GetComponent<RobotMovement>().canJump = true;
//			other.GetComponent<GravityChangeable>().SetGravity(GetComponent<GravityChangeable>().gravity);
//			other.transform.parent = null;
//		}
//
//		boundCharacter.Clear();
//		GetComponent<Explodable>().Explosion();
//		Destroy(gameObject); 
//	}
//
//	public void OnTeleportEnter()
//	{
//		teleporting = true;
//		foreach (PatrollerStopper ps in GetComponentsInChildren<PatrollerStopper>())
//			ps.OnDeath(true);
//		foreach (GameObject go in boundCharacter)
//		{
//			go.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
//			go.GetComponent<MovementEngine>().addedForce = Vector3.zero;
//			go.GetComponent<GravityChangeable>().UnaffectGravity(); 
//		}
//	}
//
//	public void OnTeleportExit()
//	{
//		teleporting = false;
//		foreach (PatrollerStopper ps in GetComponentsInChildren<PatrollerStopper>())
//			ps.OnDeath(false);
//		foreach (GameObject go in boundCharacter)
//		{
//			go.GetComponent<GravityChangeable>().SetGravity(GetComponent<GravityChangeable>().gravity);
//		}
//	}
//
//	public void OnRotation(bool finished, Gravity gravity = Gravity.Down)
//	{
//		if (!finished)
//		{
//			foreach (GameObject go in boundCharacter)
//			{
//				go.GetComponent<RobotMovement>().canJump = false; 
//				go.GetComponent<GravityChangeable>().UnaffectGravity();
//			}
//		}
//		else
//		{
//			foreach (GameObject go in boundCharacter)
//			{
//				go.GetComponent<RobotMovement>().canJump = true;
//				go.GetComponent<GravityChangeable>().SetGravity(gravity);
//			}
//		}
//	}
//
//	public void OnFalling()
//	{
//		foreach (GameObject go in boundCharacter)
//		{
//			go.GetComponent<GravityChangeable>().UnaffectGravity();
//		}
//	}
//
//	public void OnLanding()
//	{
//		foreach (GameObject go in boundCharacter)
//		{
//			go.GetComponent<GravityChangeable>().SetGravity(GetComponent<GravityChangeable>().gravity);
//		}
//	}
//
//	public void RemoveMe(GameObject go)
//	{
//		OnLanding();
//		UnbindCharacter(go);       
//	}
//
//}

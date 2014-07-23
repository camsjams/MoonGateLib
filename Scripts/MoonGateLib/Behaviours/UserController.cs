namespace MoonGateLib.Behaviours
{
	using UnityEngine;
	using System;
	using System.Collections;
	using MoonGateLib.Types;

	[System.Serializable]
	public class Boundary
	{
		public float xMin, xMax, zMin, zMax;
	}

	public class UserController : MonoBehaviour
	{

		public float speed = 3;

		public Boundary boundary;

		public bool isEnforcingBoundary = false;

		public float turnSmoothing = 15f;   // A smoothing value for turning the player.

		protected Animator _anim;

		void Awake()
		{
			_anim = GetComponent<Animator>();
		}

		protected void FixedUpdate()
		{

			float adjustedSpeed = 0.0f;
			if (Input.GetKey(KeyCode.LeftShift))
			{
				_anim.SetBool("IsRunning", true);
				adjustedSpeed = speed * 2;
			}
			else
			{
				_anim.SetBool("IsRunning", false);
				adjustedSpeed = speed;
			}
			float moveHorizontal = Input.GetAxis("Horizontal");
			float moveVertical = Input.GetAxis("Vertical");

			Movement(moveHorizontal, moveVertical, adjustedSpeed);
		}

		void Movement(float moveHorizontal, float moveVertical, float adjustedSpeed)
		{
			if (CanMove() && (Math.Abs(moveHorizontal) > 0 || Math.Abs(moveVertical) > 0))
			{
				_anim.SetBool("IsMoving", true);
				Rotating(moveHorizontal, moveVertical);
				// calculate velocity
				Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
				rigidbody.velocity = movement * adjustedSpeed;
			}
			else
			{
				_anim.SetBool("IsMoving", false);
			}
			CheckBoundary();
		}

		void CheckBoundary()
		{
			if (isEnforcingBoundary)
			{
				rigidbody.position = new Vector3
				(
					Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
					0.0f,
					Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
				);
			}
		}

		void Rotating(float horizontal, float vertical)
		{
			// Create a new vector of the horizontal and vertical inputs.
			Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);

			// Create a rotation based on this new vector assuming that up is the global y axis.
			Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);

			// Create a rotation that is an increment closer to the target rotation from the player's rotation.
			Quaternion newRotation = Quaternion.Lerp(rigidbody.rotation, targetRotation, turnSmoothing * Time.deltaTime);

			// Change the players rotation to this new rotation.
			rigidbody.MoveRotation(newRotation);
		}

		protected bool CanMove()
		{
			if (!_anim.GetBool("IsDodging"))
			{
				return true;
			}
			return false;
		}

	}
}
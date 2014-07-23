namespace MoonGateLib.Camera
{
	using UnityEngine;
	using System.Collections;

	[System.Serializable]
	public class Boundary
	{
		public float xMin, xMax, zMin, zMax;
	}

	/**
	 * Isometric Camera Follow Component
	 * 
	 * @desc allows camera to follow object as
	 * isometric camera using x or z coordinates. 
	 * y coordinate is frozen at zero
	 * 
	 * @author Cameron Manavian
	 * @version 0.1
	 * 
	 */
	public class IsometricCamera : MonoBehaviour
	{
		public Transform target;
		public Boundary boundary;

		void LateUpdate()
		{
			if (target)
			{
				SnapToTarget();
			}
		}

		void SnapToTarget()
		{
			float targetX = target.position.x - transform.position.x;
			float targetZ = target.position.z - transform.position.z;
			transform.Translate(targetX, 0, targetZ);
		}

		void SetTargetAndCenter(Transform newTarget)
		{
			target = newTarget;
			SnapToTarget();
		}
	}
}
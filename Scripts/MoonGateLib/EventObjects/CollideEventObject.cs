namespace MoonGateLib.EventObjects
{
	using UnityEngine;

	class CollideEventObject
	{
		/// <summary>
		///  The targetBody is the receiver of the collision and is the one notified about impact
		/// </summary>
		public GameObject targetBody;

		/// <summary>
		///  The originBody is the cause of the collision
		/// </summary>
		public GameObject originBody;
	}
}

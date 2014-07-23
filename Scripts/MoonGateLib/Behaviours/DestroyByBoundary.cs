namespace MoonGateLib.Behaviours
{
	using UnityEngine;
	using MoonGateLib.Types;

	public class DestroyByBoundary : MonoBehaviour
	{

		void OnTriggerExit(Collider other)
		{
			Destroy(other.gameObject);
		}
	}
}
namespace MoonGateLib.Behaviours
{
	using UnityEngine;

	public class SelfDestruct : MonoBehaviour
	{
		public float timeLeftOnEarth = 5;

		// Update is called once per frame
		void Update()
		{
			if (timeLeftOnEarth > 0)
			{
				timeLeftOnEarth -= Time.deltaTime;
			}
			else
			{
				Destroy(gameObject);
			}
		}
	}
}
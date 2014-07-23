namespace MoonGateLib.Behaviours
{
	using UnityEngine;

	class LightBehavior : MonoBehaviour
	{
		// Properties
		public string waveFunction = "flicker"; // possible values: sin, tri(angle), sqr(square), saw(tooth), inv(verted sawtooth), noise (random)
		public float baseWave = 0.0f; // base wave amount
		public float amplitude = 1.0f; // amplitude of the wave
		public float phase = 0.0f; // start point inside on wave cycle
		public float frequency = 0.7f; // cycle frequency per second

		// Keep a copy of the original color
		private Color _originalColor;

		private int _flicker = 0;

		private Light _light;

		// Store the original color
		void Start()
		{
			_originalColor = GetComponent<Light>().color;
			_light = GetComponent<Light>();
		}

		void Update()
		{
			_light.color = _originalColor * (EvalWave());
		}

		float EvalWave()
		{
			float x = (Time.time + phase) * frequency;
			float y;

			x = x - Mathf.Floor(x); // normalized value (0..1)

			if (waveFunction == "sin")
			{
				y = Mathf.Sin(x * 2 * Mathf.PI);
			}
			else if (waveFunction == "tri")
			{
				if (x < 0.5)
					y = 4.0f * x - 1.0f;
				else
					y = -4.0f * x + 3.0f;
			}
			else if (waveFunction == "sqr")
			{
				if (x < 0.5)
					y = 1.0f;
				else
					y = -1.0f;
			}
			else if (waveFunction == "saw")
			{
				y = x;
			}
			else if (waveFunction == "inv")
			{
				y = 1.0f - x;
			}
			else if (waveFunction == "noise")
			{
				y = 1 - (Random.value * 2);
			}
			else if (waveFunction == "flicker")
			{
				if (_flicker > 4)
				{
					_flicker = 0;
					y = 1 - (Random.value);
				}
				else
				{
					_flicker++;
					y = frequency;
				}
			}
			else
			{
				y = 1.0f;
			}
			return (y * amplitude) + baseWave;
		}

	}
}

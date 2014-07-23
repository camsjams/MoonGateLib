namespace MoonGateLib.Behaviours
{
	using UnityEngine;
	using System;

	public class PlayerAbilityBehavior : MonoBehaviour
	{

		public float cooldown = 2.0f;

		public GUIText statusText;

		public string textPrefix;

		public Color cooldownCooling = Color.white;

		public Color cooldownCool;

		protected bool _isOnCooldown = false;

		private float _cooldownTime = 0.0f;

		protected Animator _anim;

		protected bool _isUsingAbility = false;

		protected void SetupGameComponents() {
			_anim = GetComponent<Animator>();
		}

		protected void UpdateCooldown()
		{
			if (_isOnCooldown)
			{
				if (_cooldownTime <= Time.time)
				{
					_isOnCooldown = false;
					UpdateText(cooldown);
				}
				else
				{
					UpdateText((float)Math.Round((decimal)_cooldownTime - (decimal)Time.time, 1));
				}
			}
			else
			{
				UpdateText(cooldown);
			}
		}

		protected void StartCooldown()
		{
			_cooldownTime = Time.time + cooldown;
			_isOnCooldown = true;
			_isUsingAbility = true;
		}

		void UpdateText(float cool)
		{
			if (_isOnCooldown)
			{
				statusText.color = cooldownCooling;
			}
			else
			{
				statusText.color = cooldownCool;
			}
			statusText.text = textPrefix + cool + "s";
		}

		protected bool isAbleToUseAbility()
		{
			if (!_isUsingAbility && !_isOnCooldown)
			{
				return true;
			}
			return false;
		}
	}
}

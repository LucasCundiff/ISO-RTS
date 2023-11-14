using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
	public PlayerInput PlayerInput;

	private void OnEnable()
	{
		if (PlayerInput == null)
			PlayerInput = new PlayerInput();

		PlayerInput.Enable();		
	}

	private void OnDisable()
	{
		PlayerInput?.Disable();
	}
}

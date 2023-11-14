using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
	public InputManager input;
	public float moveSpeed = 0.5f;
	float moveThreshold = 5f;

	Vector3 mousePos;
	Vector3 moveDir;
	Vector3 up = new Vector3(-1, 0, 1);
	Vector3 down = new Vector3(1, 0, -1);
	Vector3 left = new Vector3(-1, 0, -1);
	Vector3 right = new Vector3(1, 0, 1);

	public void Update()
	{
		mousePos = input.PlayerInput.Player.Mouse.ReadValue<Vector2>();
		moveDir = Vector3.zero;

		if (mousePos.x < moveThreshold)
		{
			moveDir += left;
		}
		if (mousePos.x > Screen.width - moveThreshold)
		{
			moveDir += right;
		}
		if (mousePos.y < moveThreshold)
		{
			moveDir += down;
		}
		if (mousePos.y > Screen.height - moveThreshold)
		{
			moveDir += up;
		}

		moveDir.Normalize();
		transform.Translate(moveDir * moveSpeed);
	}
}

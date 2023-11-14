using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractableFunction : ScriptableObject
{
	public Sprite Sprite;

	protected InputAction cInput;
	protected Interactable cInteractable;

	public virtual void Enable(InputAction input, Interactable interactable)
	{
		input.performed += FunctionWrapper;
		cInteractable = interactable;
	}
	public virtual void Disable(InputAction input)
	{
		input.performed -= FunctionWrapper;
		cInteractable = null;
	}

	public virtual void FunctionWrapper(InputAction.CallbackContext context) => Function();

	public virtual void Function()
	{

	}
}

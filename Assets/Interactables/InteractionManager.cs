using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class InteractionManager : MonoBehaviour, IPointerClickHandler
{
	public InputManager input;
	public InteractionUI interactionUI;
	public Interactable cInteractable;

	public Action OnLeftClickedEvent;
	public Action OnRightClickedEvent;

	public void Start()
	{
		OnLeftClickedEvent += SelectInteractable;
		input.PlayerInput.Player.Escape.performed += UnselectInteractableWrapper;
	}


	public void OnDisable()
	{
		OnRightClickedEvent += SelectInteractable;
		input.PlayerInput.Player.Escape.performed -= UnselectInteractableWrapper;
	}

	private void SelectInteractableWrapper(InputAction.CallbackContext obj) => SelectInteractable();
	private void UnselectInteractableWrapper(InputAction.CallbackContext obj) => UnselectInteractable();

	private void SelectInteractable()
	{
		Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, Mathf.Infinity))
		{
			if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Default"))
			{
				UnselectInteractable();
				return;
			}
			var ni = hit.collider.GetComponent<Interactable>();
			if (ni != null)
				AssignNewInteractable(ni);
		}
	}

	private void UnselectInteractable()
	{
		cInteractable?.Disable();
		interactionUI.HideUI();
		cInteractable = null;
	}

	private void AssignNewInteractable(Interactable interactable)
	{
		cInteractable?.Disable();
		cInteractable = interactable;
		cInteractable.Enable(this);
		interactionUI.ShowUI(cInteractable);
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
			OnLeftClickedEvent?.Invoke();
		if (eventData.button == PointerEventData.InputButton.Right)
			OnRightClickedEvent?.Invoke();

	}

	/*
	 Later when adding other hotkeys subscribe them here so that they can be replaced if needed
	 
	 */
}

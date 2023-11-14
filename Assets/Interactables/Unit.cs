using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(NavMeshAgent))]
public class Unit : Interactable
{
	protected NavMeshAgent agent;

	protected virtual  void Start()
	{
		agent = GetComponent<NavMeshAgent>();
	}

	public override void Enable(InteractionManager IM)
	{
		base.Enable(IM);
		cIM.OnRightClickedEvent += Select;
	}

	public override void Disable()
	{
		cIM.OnRightClickedEvent -= Select;
		base.Disable();
	}

	protected void Select()
	{
		Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, Mathf.Infinity))
		{
			UnitInteract(hit);
		}
	}

	protected virtual void UnitInteract(RaycastHit hit)
	{
		int layerType = hit.collider.gameObject.layer;
		if (layerType == LayerMask.NameToLayer("Default"))
			Move(hit.point);
		else if (layerType == LayerMask.NameToLayer("Unit"))
			Combat(hit.collider.gameObject.GetComponent<Interactable>());
	}

	private void Combat(Interactable interactable)
	{
		agent.destination = interactable.transform.position;
		Debug.Log($"{this} is now fighting {interactable}");
	}

	private void Move(Vector3 point)
	{
		agent.destination = point;
	}
}
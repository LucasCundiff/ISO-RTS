using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnitBuilding : Building
{
	public Transform spawnPoint;

	public override void Enable(InteractionManager IM)
	{
		base.Enable(IM);
		cIM.OnRightClickedEvent += SetNewSpawnPoint;
	}

	public override void Disable()
	{
		cIM.OnRightClickedEvent -= SetNewSpawnPoint;
		base.Disable();
	}

	private void SetNewSpawnPoint()
	{
		Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, Mathf.Infinity))
		{
			if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Default"))
				spawnPoint.position = hit.point + Vector3.up;
		}
	}
}

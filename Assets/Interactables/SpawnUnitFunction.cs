using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Functions/Spawn Unit")]
public class SpawnUnitFunction : InteractableFunction
{
	public Unit unit;

	public override void Function()
	{
		var u = (UnitBuilding)cInteractable;
		if (u)
		{
			var nu = Instantiate(unit.gameObject, u.spawnPoint, false);
			nu.transform.parent = null;
		}
			
	}
}

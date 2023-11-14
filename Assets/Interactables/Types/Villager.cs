using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Villager : Unit
{
	public BuildingPlan buildingOnePlan;
	public BuildingPlan buildingTwoPlan;
	public BuildingPlan buildingThreePlan;
	public BuildingPlan buildingFourPlan;

	bool building = false;
	BuildingPlan planInstance;


	public override void Enable(InteractionManager IM)
	{
		base.Enable(IM);

		if (cIM)
		{
			cIM.OnRightClickedEvent += Select;
			cIM.input.PlayerInput.VillagerCommands.Action1.performed += BuildingOneWrapper;
			cIM.input.PlayerInput.VillagerCommands.Action2.performed += BuildingTwoWrapper;
			cIM.input.PlayerInput.VillagerCommands.Action3.performed += BuildingThreeWrapper;
			cIM.input.PlayerInput.VillagerCommands.Action4.performed += BuildingFourWrapper;
		}
	}

	public override void Disable()
	{
		if (cIM)
		{
			cIM.OnRightClickedEvent -= Select;
			cIM.input.PlayerInput.VillagerCommands.Action1.performed -= BuildingOneWrapper;
			cIM.input.PlayerInput.VillagerCommands.Action2.performed -= BuildingTwoWrapper;
			cIM.input.PlayerInput.VillagerCommands.Action3.performed -= BuildingThreeWrapper;
			cIM.input.PlayerInput.VillagerCommands.Action4.performed -= BuildingFourWrapper;
			if (planInstance) Destroy(planInstance.gameObject);
			if (building)
			{
				cIM.OnRightClickedEvent -= BuildInstance;
				building = false;
			}
		}

		base.Disable();
	}


	private void BuildInstance()
	{
		planInstance?.Build();
	}

	private void BuildingOneWrapper(InputAction.CallbackContext obj)
	{
		BuildState(buildingOnePlan);
	}

	private void BuildingTwoWrapper(InputAction.CallbackContext obj)
	{
		BuildState(buildingTwoPlan);
	}

	private void BuildingThreeWrapper(InputAction.CallbackContext obj)
	{
		BuildState(buildingThreePlan);
	}

	private void BuildingFourWrapper(InputAction.CallbackContext obj)
	{
		BuildState(buildingFourPlan);
	}

	private void BuildState(BuildingPlan buildingPlan)
	{
		if (building)
		{
			if (planInstance && buildingPlan.buildingPrefab.iName == planInstance.buildingPrefab.iName)
			{
				Building(false);
				if (planInstance) Destroy(planInstance.gameObject);
			}
			else
			{
				Destroy(planInstance.gameObject);
				planInstance = Instantiate(buildingPlan);
			}
		}
		else
		{
			Building(true);
			planInstance = Instantiate(buildingPlan);
		}
	}

	private void Building(bool state)
	{
		if (state)
		{
			cIM.OnRightClickedEvent += BuildInstance;
			cIM.OnRightClickedEvent -= Select;
		}
		else
		{
			cIM.OnRightClickedEvent -= BuildInstance;
			cIM.OnRightClickedEvent += Select;
		}

		building = state;
	}
}

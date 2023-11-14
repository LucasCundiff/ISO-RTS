using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable: MonoBehaviour
{
	public Sprite icon;
	public string iName;
	public InteractionManager cIM;

	public InteractableFunction function1;
	public InteractableFunction function2;
	public InteractableFunction function3;
	public InteractableFunction function4;

	public virtual void Enable(InteractionManager IM)
	{
		cIM = IM;
		if (function1)
			 function1.Enable(cIM.input.PlayerInput.BuildingCommands.Action1, this);
		if (function2)
			function2.Enable(cIM.input.PlayerInput.BuildingCommands.Action2, this);
		if (function3)
			function3.Enable(cIM.input.PlayerInput.BuildingCommands.Action3, this);
		if (function4)
			function4.Enable(cIM.input.PlayerInput.BuildingCommands.Action4, this);
	}

	public virtual void Disable()
	{
		if (function1)
			function1.Disable(cIM.input.PlayerInput.BuildingCommands.Action1);
		if (function2)
			function2.Disable(cIM.input.PlayerInput.BuildingCommands.Action2);
		if (function3)
			function3.Disable(cIM.input.PlayerInput.BuildingCommands.Action3);
		if (function4)
			function4.Disable(cIM.input.PlayerInput.BuildingCommands.Action4);
		cIM = null;
	}
}

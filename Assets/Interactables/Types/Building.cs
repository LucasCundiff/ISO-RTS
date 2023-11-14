using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Building : Interactable
{
	public List<string> names;
	public List<Sprite> sprites;

	private void Start()
	{
		iName = names[Random.Range(0, names.Count)];
		icon = sprites[Random.Range(0, sprites.Count)];
	}

}

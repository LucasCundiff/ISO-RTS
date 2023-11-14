using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class InteractableButton : MonoBehaviour, IPointerClickHandler
{
	protected InteractableFunction function;
	public InteractableFunction cFunction
	{
		get { return function; }
		set
		{
			function = value;

			if (function)
				Icon.sprite = function.Sprite;

			gameObject.SetActive(function);
		}
	}
	public Image Icon;

	public void OnPointerClick(PointerEventData eventData)
	{
		cFunction.Function();
	}
}

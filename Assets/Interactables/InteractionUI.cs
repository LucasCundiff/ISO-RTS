using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractionUI : MonoBehaviour
{
	public TextMeshProUGUI iName;
	public Image image;
	public InteractableButton button1;
	public InteractableButton button2;
	public InteractableButton button3;
	public InteractableButton button4;

	public void Start()
	{
		HideUI();
	}

	public void ShowUI(Interactable interactable)
	{
		iName.text = interactable.iName;
		image.sprite = interactable.icon;

		button1.cFunction = interactable.function1;
		button2.cFunction = interactable.function2;
		button3.cFunction = interactable.function3;
		button4.cFunction = interactable.function4;

		gameObject.SetActive(true);
	}

	public void HideUI()
	{
		gameObject.SetActive(false);
	}
}

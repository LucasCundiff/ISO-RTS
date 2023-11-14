using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BuildingPlan : MonoBehaviour
{
	public LayerMask targetableLayers;
	public Building buildingPrefab;
	public Material ableMat, unableMat;
	public MeshRenderer mesh;
	public List<Collider> interruptingColliders = new List<Collider>();

	Vector2 lastPosition;

	public void Update()
	{
		UpdateLocation();
		UpdateColor();
	}

	private void UpdateColor()
	{
		if (CanBuild())
			mesh.material = ableMat;
		else
			mesh.material = unableMat;
	}

	private void UpdateLocation()
	{
		if (Mouse.current.position.ReadValue() != lastPosition)
		{
			lastPosition = Mouse.current.position.ReadValue();
			Ray ray = Camera.main.ScreenPointToRay(lastPosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, Mathf.Infinity, targetableLayers, QueryTriggerInteraction.Ignore))
			{
				if (hit.collider.isTrigger) return;

				transform.position = hit.point;

				mesh.enabled = true;
			}
			else
			{
				mesh.enabled = false;
			}
		}
	}


	public void Build()
	{
		if (CanBuild())
		{
			var nb = Instantiate(buildingPrefab);
			nb.transform.position = transform.position;
		}
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.isTrigger)
			interruptingColliders.Add(other);
	}

	public void OnTriggerExit(Collider other)
	{
		if (interruptingColliders.Contains(other))
			interruptingColliders.Remove(other);
	}

	public bool CanBuild() { return interruptingColliders.Count == 0; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Interactable
{
	[SerializeField] Action action;

	[SerializeField] Inventory inventory;
	public override void OnInteractActive(GameObject gameObject)
	{
		throw new System.NotImplementedException();
	}

	public override void OnInteractEnd(GameObject gameObject)
	{
		throw new System.NotImplementedException();
	}

	public override void OnInteractStart(GameObject gameObject)
	{
		throw new System.NotImplementedException();
	}
}

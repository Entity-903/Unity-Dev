using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Interactable
{
	[SerializeField] private Action action;
	[SerializeField] private IntEvent scoreEvent;
	//[SerializeField] private Inventory inventory;
	[SerializeField] private FloatVariable score;
	[SerializeField] private FloatVariable health;

	[SerializeField] private GameObject hitPrefab;
	[SerializeField] private GameObject destroyPrefab;

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

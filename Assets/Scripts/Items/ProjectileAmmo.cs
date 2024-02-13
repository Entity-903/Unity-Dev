using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAmmo : Ammo
{
    [SerializeField] Action action;

	private void Start()
	{
		if (action != null)
		{
			action.onEnter += OnInteractStart;
			action.onStay += OnInteractActive;
		}
	}
}

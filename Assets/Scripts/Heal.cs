using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
	[SerializeField]
	int heal = 33;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.TryGetComponent<Player>(out Player player))
		{
			player.Damage(-heal);
			Destroy(this.gameObject);
		}
	}
}

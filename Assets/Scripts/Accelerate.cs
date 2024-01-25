using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerate : MonoBehaviour
{
	[SerializeField]
	Vector3 speed = Vector3.zero;

	[SerializeField]
	bool oneTime = false;

	private void OnTriggerEnter(Collider other)
	{
		if (oneTime && other.gameObject.TryGetComponent<Player>(out Player player))
		{
			player.GetRigidbody().AddForce(speed);
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (!oneTime && other.gameObject.TryGetComponent<Player>(out Player player))
		{
			player.GetRigidbody().AddForce(speed);
		}
	}
}

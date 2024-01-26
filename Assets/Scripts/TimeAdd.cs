using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAdd : MonoBehaviour
{
	[SerializeField]
	int time = 60;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.TryGetComponent<Player>(out Player player))
		{
			GameManager.Instance.OnAddTime(time);
			Destroy(this.gameObject);
		}
	}
}

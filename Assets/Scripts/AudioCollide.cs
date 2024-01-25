using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCollide : MonoBehaviour
{
	[SerializeField]
	AudioClip sound;
	// Start is called before the first frame update
	private void OnTriggerEnter(Collider other)
	{
		AudioSource.PlayClipAtPoint(sound, transform.position);
	}
}

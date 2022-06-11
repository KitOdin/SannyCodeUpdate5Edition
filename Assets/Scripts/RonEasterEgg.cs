using UnityEngine;
using System.Collections;

public class RonEasterEgg : MonoBehaviour
{
	public AudioClip ok;
	public AudioSource woah;
	// Use this for initialization
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			woah.PlayOneShot (ok);
		}
	}
}


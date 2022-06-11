using UnityEngine;
using System.Collections;

public class FileProjectile : MonoBehaviour
{
	PlayerController player;
	bool hasTriggered = false;
	AudioSource temmie;
	public AudioClip bong;
	// Use this for initialization
	void Start ()
	{
		player = FindObjectOfType<PlayerController> ();
		temmie = GetComponent<AudioSource> ();
		Invoke ("BLOWJOBMOMENT", 7f);
	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collision other)
	{
		if (other.transform.tag == "Player") 
		{
			if (!hasTriggered) 
			{
				player.canMove = false;
				temmie.PlayOneShot (bong);
				Invoke ("unlockPlayer", 3f);
				hasTriggered = true;
			}
		}
	}

	void BLOWJOBMOMENT()
	{
		Destroy(base.gameObject);
	}

	void unlockPlayer()
	{
		player.canMove = true;
	}
}


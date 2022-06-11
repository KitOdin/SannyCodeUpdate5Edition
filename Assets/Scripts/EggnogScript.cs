using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggnogScript : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter(Collider other) 
	{
		if(other.tag == "Player")
		{
			FindObjectOfType<GameController>().CollectEggnog();
			Destroy (base.gameObject);
		}	
	}
}

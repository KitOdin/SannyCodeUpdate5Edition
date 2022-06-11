using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class TheIce : MonoBehaviour
{
	GameObject[] wanderPoints;
	public PlayerController player;
	public GameObject AAAAAAAAAAA;
	// Use this for initialization
	void Start ()
	{
		wanderPoints = GameObject.FindGameObjectsWithTag ("pointy");
		RESET();
	}

	// Update is called once per frame
	void Update ()
	{
		if (GetComponent<NavMeshAgent> ().velocity.magnitude <= 0.1f) 
		{
			RESET ();
		}
	}
	void RESET()
	{
		GetComponent<NavMeshAgent> ().SetDestination (wanderPoints [UnityEngine.Random.Range (0, wanderPoints.Length - 1)].transform.position);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			player.Freeze ();
			base.Invoke("UNFREEZER", 5f);
		}
	}

	void UNFREEZER()
	{
		player.UnFreeze();
	}
}


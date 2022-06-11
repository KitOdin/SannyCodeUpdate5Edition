using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class ScrewDriveryScript : MonoBehaviour
{
	GameObject[] wanderPoints;
	float origSpeed;
	// Use this for initialization
	void Start ()
	{
		wanderPoints = GameObject.FindGameObjectsWithTag ("pointy");
		origSpeed = GetComponent<NavMeshAgent> ().speed;
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
		if (other.gameObject.GetComponent<DoorScript> () != null) 
		{
			other.GetComponent<DoorScript> ().Repair ();
		}	
		if(other.name == "The ice")
		{
			Freeze ();
		}	
	}

	void Freeze()
	{
		GetComponent<NavMeshAgent> ().speed = 0f;
		GetComponentInChildren<SpriteRenderer> ().color = Color.cyan;
		base.Invoke ("UNFreeze", 5f);
	}
	void UNFreeze()
	{
		GetComponent<NavMeshAgent> ().speed = origSpeed;
		GetComponentInChildren<SpriteRenderer> ().color = Color.white;
	}
}


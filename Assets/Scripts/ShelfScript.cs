using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class ShelfScript : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		GetComponent<Rigidbody> ().velocity = transform.forward * 3f;
	}

	void OnTriggerStay(Collider other)
	{
		if (other.GetComponent<NavMeshAgent> () != null) 
		{
			other.GetComponent<NavMeshAgent> ().velocity = GetComponent<Rigidbody> ().velocity * other.GetComponent<NavMeshAgent> ().speed;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.GetComponent<NavMeshAgent> () != null) 
		{
			UnglueAI(other.GetComponent<NavMeshAgent> ());
		}
	}
	
	void UnglueAI(NavMeshAgent manDude)
	{
		manDude.velocity = default(Vector3);
	}
	
}


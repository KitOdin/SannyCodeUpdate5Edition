using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class FileAI : MonoBehaviour
{
	GameObject[] wanderPoints;
	public GameObject AAAAAAAAAAA;
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
		
		if (UnityEngine.Random.Range (0f, 350f) <= 1f) 
		{
			GameObject projectile = GameObject.Instantiate (AAAAAAAAAAA, base.transform.position + Vector3.up * 5f, base.transform.rotation);
			projectile.GetComponent<Rigidbody> ().AddForce (-projectile.transform.position * 25f);
		}

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


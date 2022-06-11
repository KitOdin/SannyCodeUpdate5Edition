using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class BeanyAI : MonoBehaviour
{
	GameObject[] wanderPoints;
	public AudioClip BEAN;
	float origSpeed;
	AudioSource beann;
	// Use this for initialization
	void Start ()
	{
		wanderPoints = GameObject.FindGameObjectsWithTag ("pointy");
		beann = GetComponent<AudioSource> ();
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
		if (other.tag == "Player") 
		{
			other.transform.position = wanderPoints [UnityEngine.Random.Range (0, wanderPoints.Length - 1)].transform.position;
			beann.PlayOneShot (BEAN);
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
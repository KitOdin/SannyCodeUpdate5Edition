using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class MoobAkScript : MonoBehaviour
{
	GameObject[] wanderPoints;
	public AudioClip BEAN;
	AudioSource moobAUDIO;
	float origSpeed;
	// Use this for initialization
	void Start ()
	{
		wanderPoints = GameObject.FindGameObjectsWithTag ("pointy");
		moobAUDIO = GetComponent<AudioSource> ();
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
		if (other.gameObject.GetComponent<Rigidbody> () != null && other.gameObject.GetComponent<NavMeshAgent> () == null) 
		{
			if (other.tag == "Player") {
				other.GetComponent<PlayerController> ().Boing (-transform.forward * 10f);
			} else {
				other.gameObject.GetComponent<Rigidbody> ().AddForce(-transform.forward * 10f, ForceMode.Impulse);
			}

			moobAUDIO.PlayOneShot(BEAN);
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


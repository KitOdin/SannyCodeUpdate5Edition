using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using System.Collections;

public class AngrySannyScript : MonoBehaviour
{
	GameObject[] wanderPoints;
	Transform player;
	float origSpeed;
	AudioSource asas;
	public AudioClip bong;
	public bool Spotted;
	// Use this for initialization
	void Start ()
	{
		wanderPoints = GameObject.FindGameObjectsWithTag ("pointy");
		player = FindObjectOfType<PlayerController> ().transform;
		asas = GetComponent<AudioSource> ();
		origSpeed = GetComponent<NavMeshAgent> ().speed;
		RESET();
	}
	// Update is called once per frame
	void Update ()
	{
		Vector3 direction = this.player.position - base.transform.position;
		RaycastHit bonk;
		Spotted = (Physics.Raycast (base.transform.position, direction, out bonk, float.PositiveInfinity, 3, QueryTriggerInteraction.Ignore) & bonk.transform.tag == "Player");
		if (!Spotted) {
			if (GetComponent<NavMeshAgent> ().velocity.magnitude <= 0.1f) {
				RESET ();
			}
		} 
		else {
			GetComponent<NavMeshAgent> ().SetDestination (player.position);
		}
	}
	void RESET()
	{
		GetComponent<NavMeshAgent> ().SetDestination (wanderPoints [UnityEngine.Random.Range (0, wanderPoints.Length - 1)].transform.position);
	}

	void OnTriggerEnter(Collider other) 
	{
		if(other.tag == "Player")
		{
			SceneManager.LoadScene ("GameOver");
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


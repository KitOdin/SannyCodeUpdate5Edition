using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Potatoe : MonoBehaviour
{
	GameObject[] wanderPoints;
	float origSpeed;
	public Transform player;
	public Transform bunkerPoint;
	public bool SawPlayer;

	public float MinCooldownTime;
	public float maxcooldownlol;

	float cooldown;

	public AudioSource sus;
	public AudioClip spotaud;
	public AudioClip bunkaud;
	public AudioClip safeaud;

	// Use this for initialization
	void Start ()
	{
		cooldown = Random.Range (MinCooldownTime, maxcooldownlol);
		wanderPoints = GameObject.FindGameObjectsWithTag ("pointy");
		origSpeed = GetComponent<NavMeshAgent> ().speed;
		RESET();
	}

	// Update is called once per frame
	void Update ()
	{
		Vector3 direction = this.player.position - base.transform.position;
		RaycastHit raycastHit;
		if (Physics.Raycast(base.transform.position, direction, out raycastHit, float.PositiveInfinity, 3, QueryTriggerInteraction.Ignore) & raycastHit.transform.tag == "Player")
		{
			if (cooldown <= 0f) {
				if (!SawPlayer) {
					sus.PlayOneShot (spotaud);
					SawPlayer = true;
				}
			}
		}
		if (GetComponent<NavMeshAgent> ().velocity.magnitude <= 0.1f && !SawPlayer) 
		{
			RESET ();
		}
		if (SawPlayer) 
		{
			GetComponent<NavMeshAgent> ().SetDestination (player.position);
		}
		if (cooldown > 0f) 
		{
			cooldown -= 1f * Time.deltaTime;
		}
		if (cooldown <= 0f) 
		{
			Debug.Log ("HIS COOLDOWN IS AT 0 START RUNNING THE OPPISITE DIRECTION!");
		}
	}
	void RESET()
	{
		GetComponent<NavMeshAgent> ().SetDestination (wanderPoints [UnityEngine.Random.Range (0, wanderPoints.Length - 1)].transform.position);
	}

	void OnTriggerEnter(Collider other)
	{	
		if (cooldown <= 0f) {
			if (other.name == "The ice") {
				Freeze ();
			}	
			if (other.tag == "Player") {
				player.position = bunkerPoint.position;
				base.StartCoroutine (audioSequence ());
				SawPlayer = false;
				cooldown = Random.Range (MinCooldownTime, maxcooldownlol);
			}	
			if (other.tag == "Guy") {
				other.GetComponent<NavMeshAgent> ().Warp (bunkerPoint.position);
				base.StartCoroutine (audioSequence ());
				if (!SawPlayer) 
				{
					cooldown = Random.Range (MinCooldownTime, maxcooldownlol); //we resetting
				}
			}
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

	IEnumerator audioSequence()
	{
		sus.PlayOneShot (bunkaud);
		yield return new WaitForSeconds (bunkaud.length);
		sus.PlayOneShot (safeaud);
		yield break;
	}
}


using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Gary : MonoBehaviour
{
	public SpriteRenderer spriter;
	public Sprite[] sprites;
	float angle;
	public Transform player;
	// Use this for initialization
	void Start ()
	{
	
	}

	void Update()
	{
		GetComponent<NavMeshAgent> ().SetDestination (player.position);
		UpdateSprite ();
	}

	// Update is called once per frame
	void UpdateSprite ()
	{
		Vector3 direction = (player.position - base.transform.position);
		float angleF = Mathf.Atan2 (direction.z, direction.x)  * 57.29578f;
		if (angleF < 0f) 
		{
			angleF += 360f;
		}
		angleF += base.transform.rotation.eulerAngles.y;
		angle = (angleF / 90f);
		while (angle < 0 || angle >= sprites.Length) 
		{
			angle += (-sprites.Length * Mathf.Sign (angle));
		}
		print (Mathf.Floor(angle));
		spriter.sprite = sprites [Mathf.RoundToInt (Mathf.Floor(angle))];
	}
	void OnTriggerEnter(Collider other)
	{	
		if(other.tag == "Player")
		{
			player.GetComponent<PlayerController> ().Boing (transform.forward * 69f);
		}	
	}
}


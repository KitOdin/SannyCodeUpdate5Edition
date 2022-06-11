using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float Speed;
	private Rigidbody rb;
	public string PlatTag;
	private Vector3 Movement;
	public bool OnGround;
	public float Sensitvity;
	public bool Jumpable;
	public float movementSpeed;
	public float JumpHeight;
	public bool canMove;
	public GameObject freezeOverlay;
	public bool Boinged;

	// Use this for initialization
	void Start ()
	{
		movementSpeed = Speed;
		rb = GetComponent<Rigidbody> ();
		Sensitvity = PlayerPrefs.GetFloat ("mouseSense");
	}
	
	// Update is called once per frame
	void Update ()
	{
		float horizontalMovement = Input.GetAxisRaw ("Horizontal");
		float verticalMovement = Input.GetAxisRaw ("Vertical");
		float mouseRoation = Input.GetAxisRaw ("MouseX");
		
		
		base.transform.Rotate(0f, mouseRoation * Sensitvity, 0f);
		if(canMove)
		{
			Movement = (horizontalMovement * transform.right + verticalMovement * transform.forward).normalized;
		}
	}

	void FixedUpdate()
	{
		if(canMove)
		{
			Move ();
		}
		
	}

	void Move()
	{
		Vector3 yVelFix = new Vector3 (0, rb.velocity.y, 0);

		if (!Boinged) {
			rb.velocity = Movement * movementSpeed * Time.deltaTime * 100f;
		}
		if (Jumpable && Input.GetKeyDown (KeyCode.Space) && OnGround) 
		{
			rb.AddForce (Vector3.up * JumpHeight, ForceMode.Impulse);
			OnGround = false;
		}
	}
	
	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Ground")
		{
			OnGround = true;
		}
	}

	public void Jump()
	{
		if (Jumpable && OnGround) 
		{
			rb.AddForce (Vector3.up * JumpHeight, ForceMode.Impulse);
			OnGround = false;
		}
	}

	public void Freeze()
	{
		movementSpeed = 0f;
		freezeOverlay.SetActive (true);
	}
	public void UnFreeze()
	{
		movementSpeed = Speed;
		freezeOverlay.SetActive (false);
	}

	public void Boing(Vector3 force)
	{
		Boinged = true;
		rb.AddForce (force, ForceMode.Impulse);
		base.Invoke ("deboing", 3f);
	}

	void deboing()
	{
		Boinged = false;
	}
}


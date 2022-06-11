using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour
{
	Rigidbody rb;
	Quaternion originalRotation;
	Vector3 originalPosition;
	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		originalPosition = transform.position;
		originalRotation = transform.rotation;
	}

	public void Repair()
	{
		rb.isKinematic = true;
		transform.position = originalPosition;
		transform.rotation = originalRotation;
		rb.isKinematic = false;
	}
}


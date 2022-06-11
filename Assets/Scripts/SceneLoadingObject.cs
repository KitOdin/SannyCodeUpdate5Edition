using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoadingObject : MonoBehaviour
{
	public string Scn;
	void OnTriggerEnter(Collider other) 
	{
		if(other.tag == "Player")
		{
			SceneManager.LoadScene (Scn);
		}	
	}
}


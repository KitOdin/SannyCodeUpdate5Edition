using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFieldStart : MonoBehaviour {

	public void changeToScene(string SceneName)
	{
		SceneManager.LoadScene (SceneName);
	}
		
}
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndMonolouge : MonoBehaviour
{
	string[] monolouge =  new string[]{"...", "so you've broken reality...", "good for you...", "your stronger than i thought...", "stronger than my wife, ;)", "you've outsmarted me...", "well atleast me in 4th grade", "your really good...", "maybe one day we will meet again...", "..."};
	AudioSource audioSource;
	public AudioClip Spoop;
	int curMonolouge = 0;
	public Text lmao;
	public GameObject scare;

	// Use this for initialization
	void Start ()
	{
		Invoke ("poopoo", 3f);
		audioSource = GetComponent<AudioSource> ();
	}
	void poopoo()
	{
		lmao.text = monolouge [curMonolouge];
		Invoke ("bamBam", 3f);
	}
	void bamBam()
	{
		curMonolouge++;
		if (curMonolouge >= monolouge.Length) 
		{
			SpookScare ();
			return;
		}
		lmao.text = monolouge [curMonolouge];
		Invoke ("bamBam", 3f);
	}

	// Update is called once per frame
	void SpookScare()
	{
		audioSource.PlayOneShot (Spoop);
		lmao.gameObject.SetActive (false);
		scare.SetActive (true);
		Invoke ("shuttingDown", Spoop.length);
	}

	void shuttingDown()
	{
		PlayerPrefs.SetInt ("HasBootedSite", 1);
		PlayerPrefs.Save ();
		Application.Quit ();
	}
}


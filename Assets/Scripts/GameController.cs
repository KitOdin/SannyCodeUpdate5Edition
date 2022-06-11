using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
	int CurrentEggnog;
	int allEggnog;
	public GameObject sannyMAD;
	public GameObject sannyBOI;
	public GameObject shelf;
	public Rigidbody blockage;

	[Space(12)]
	[Header("Audio")]
	public AudioClip sannyTriggered;
	public AudioClip sannyHi;
	public AudioClip BASS;
	public AudioClip collectNoise;
	public AudioClip finaleNoise;
	public AudioSource musica; //MMMMUUUUUUUUUSSSIIIIIIIICCCCCCCAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
	AudioSource thing;

	[Space(12)]
	[Header("UI")]
	public Text eggnogText;

	// Use this for initialization
	void Start ()
	{
		allEggnog = FindObjectsOfType<EggnogScript> ().Length;
		thing = GetComponent<AudioSource> ();
		eggnogText.text = "0/" + allEggnog.ToString () + " Eggnog";
		thing.PlayOneShot (sannyHi);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void CollectEggnog()
	{
		CurrentEggnog++;
		eggnogText.text = CurrentEggnog.ToString () + "/" + allEggnog.ToString () + " Eggnog";
		thing.PlayOneShot (collectNoise);
		onCollectEggnog ();
	}

	void onCollectEggnog()
	{
		switch (CurrentEggnog) 
		{
		case 1:
			sannyMAD.SetActive (true);
			sannyBOI.SetActive (false);
			thing.PlayOneShot (sannyTriggered);
			musica.Stop ();
			break;
		}
		if (isAllEggnog ()) 
		{
			shelf.SetActive (true);
			blockage.isKinematic = false;
			blockage.GetComponent<BoxCollider>().enabled = false;
			blockage.AddForce (Vector3.back * 10f, ForceMode.Impulse);
			musica.clip = BASS;
			musica.Play();
			RenderSettings.ambientLight = new Color(1f, 0.5f, 0.0f);
			Camera.main.fieldOfView += 25f;
			thing.PlayOneShot (finaleNoise);
		}
	}
	bool isAllEggnog()
	{
		return (CurrentEggnog == allEggnog);
	}
}


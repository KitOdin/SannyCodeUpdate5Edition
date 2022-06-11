using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsManager : MonoBehaviour
{
	public Animator meap;
	public Toggle fxToggle;
	public Slider sensitivtySlider;
	void Start()
	{
		
	}

	public void SliderAction(string woahman)
	{
		PlayerPrefs.SetFloat (woahman, sensitivtySlider.value);
		PlayerPrefs.Save ();
	}

	public void OnOpen()
	{
		meap.Play ("BEGIN");
		fxToggle.isOn = SaveProgress.GetBoolean ("effectsOn");
		print (fxToggle.isOn);
		sensitivtySlider.value = PlayerPrefs.GetFloat("mouseSense");
	}

	public void ToggleAction(string vall)
	{
		bool hotcoffee = SaveProgress.GetBoolean (vall);
		hotcoffee = !hotcoffee;
		print (hotcoffee);
		SaveProgress.SetBoolean (vall, hotcoffee);
	}
}


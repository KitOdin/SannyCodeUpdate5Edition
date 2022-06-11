using UnityEngine;
using System.Collections;

public class SaveProgress : MonoBehaviour
{
	public static bool GetBoolean(string valuee)
	{
		int b = PlayerPrefs.GetInt (valuee);
		bool c = false;
		switch (b) 
		{
		case 1:
			c = true;
			break;
		}
		return c;
	}

	public static void SetBoolean(string keyMan, bool Boooooooo)
	{
		int dres = 0;
		if(Boooooooo)
		{
			dres = 1;
		}
		PlayerPrefs.SetInt (keyMan, dres);
		print (dres);
		print (PlayerPrefs.GetInt(keyMan));
		PlayerPrefs.Save ();
	}
}
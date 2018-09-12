using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VersionNumberPrinter : MonoBehaviour 
{
	private void OnGUI() 
	{
		GUI.Label(new Rect(10, 10, 100, 20),"Version: " + Application.version.ToString());
	}
}

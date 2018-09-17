using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour 
{
	[SerializeField] private string npcName;

	[Header("UI")]
	public bool showingBars = false;
	[SerializeField] private GameObject UICanvas;
	[SerializeField] private Text nameText;

	void Start () 
	{
		
	}
	

	void Update () 
	{
		nameText.text = npcName;

		if(showingBars)
		{
			UICanvas.SetActive(true);
		} else 
		{
			UICanvas.SetActive(false);
		}
	}

	public void SetBars(bool value)
	{
		Debug.Log("SETTING VALUE");
		showingBars = value;
	}
}

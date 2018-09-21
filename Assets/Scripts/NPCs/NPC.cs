using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour 
{
	[SerializeField] private string npcName;

	[Header("UI")]
	public bool showingBars;
	[SerializeField] private GameObject UICanvas;
	[SerializeField] private Text nameText;

	void Start () 
	{
		
	}
	
	public string GetNpcName()
	{
		return npcName;
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
		showingBars = value;
	}

	private void OnTriggerStay(Collider other) 
	{
		if(other.gameObject.tag == "Player")
		{
			other.gameObject.SendMessage("ShowDialogueNotification", SendMessageOptions.DontRequireReceiver);
		}
	}

	private void OnTriggerExit(Collider other) 
	{
		if(other.gameObject.tag == "Player")
		{
			other.gameObject.SendMessage("CleanNotifications", SendMessageOptions.DontRequireReceiver);			
		}	
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notifications : MonoBehaviour 
{
	[SerializeField] private Text notificationText;
	[SerializeField] private GameObject notificationObject;
	public string doorNotification = "HOLD 'F' KEY TO OPEN";
	public string dialogueNotification = "PRESS 'E' TO START CONVERSATION";
	private string noneNotification = " ";

	void Start () 
	{
		
	}
	

	void Update () 
	{
		
	}

	public void ShowDialogueNotification()
	{
		notificationText.text = dialogueNotification;
	}

	public void ShowDoorNotification()
	{
		//Type(doorNotification);
		notificationText.text = doorNotification;
	}

	public void CleanNotifications()
	{
		notificationText.text = noneNotification;
	}

	IEnumerator Type (string sentence)
	{
		notificationText.text = "";
		foreach(char letter in sentence.ToCharArray())
		{
			notificationText.text += letter;
			yield return null;
		}
	}	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogueController : MonoBehaviour 
{
	[SerializeField] private GameObject dialogueUI;
	[SerializeField] private GameObject pressToStartConversation;
	[SerializeField] private GameObject notificationsBar;
	private DialogueManager dialogueManager;
	private Notifications notifications;

	private void Start() 
	{
		dialogueManager = FindObjectOfType<DialogueManager>();
		notifications.GetComponent<Notifications>();
	}

	private void OnTriggerStay(Collider other) {
		if(other.gameObject.tag == "NPC")
		{
			if(Input.GetKeyDown(KeyCode.E))
			{
				GameObject npc = other.gameObject;
				TriggerDialogue(npc);
				notifications.CleanNotifications();
			}
		}
	}

	private void OnTriggerExit(Collider other) {
		if(other.gameObject.tag == "NPC")
		{
			dialogueUI.SetActive(false);
			notificationsBar.SetActive(true);
		}
	}

	public void TriggerDialogue(GameObject npc)
	{
		dialogueUI.SetActive(true);
		notificationsBar.SetActive(false);
		Debug.Log("TRIGGER DIALOGUE");
		npc.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
	}

	private void Update() {
		if(Input.GetKeyDown(KeyCode.E))
		{
			dialogueManager.DisplayNextSentence();
		}
	}
}

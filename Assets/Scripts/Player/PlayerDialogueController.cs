using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogueController : MonoBehaviour 
{
	[SerializeField] private GameObject dialogueUI;
	[SerializeField] private GameObject pressToStartConversation;
	private DialogueManager dialogueManager;

	private void Start() {
		dialogueManager = FindObjectOfType<DialogueManager>();
	}

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "NPC")
		{
			dialogueUI.SetActive(true);
			Debug.Log("TRIGGER DIALOGUE");
			other.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
		}
	}

	private void OnTriggerExit(Collider other) {
		if(other.gameObject.tag == "NPC")
		{
			dialogueUI.SetActive(false);
		}
	}

	private void Update() {
		if(Input.GetKeyDown(KeyCode.E))
		{
			dialogueManager.DisplayNextSentence();
		}
	}
}

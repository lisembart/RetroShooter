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
			GameObject npc = other.gameObject;
			TriggerDialogue(npc);
		}
	}

	private void OnTriggerExit(Collider other) {
		if(other.gameObject.tag == "NPC")
		{
			dialogueUI.SetActive(false);
		}
	}

	public void TriggerDialogue(GameObject npc)
	{
		dialogueUI.SetActive(true);
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

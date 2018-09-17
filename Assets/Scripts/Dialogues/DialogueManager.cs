using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
	private Queue<string> sentences;

	void Start () 
	{
		sentences = new Queue<string>();
	}

	public void StartDialogue(Dialogue dialogue)
	{
		Debug.Log("Starting conversation with " + dialogue.name);
		
		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			this.sentences.Enqueue(sentence);
		}
		
		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		Debug.Log(sentence);
	}

	public void EndDialogue()
	{
		Debug.Log("End of conversation");
	}

}

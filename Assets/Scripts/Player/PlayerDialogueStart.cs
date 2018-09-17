using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogueStart : MonoBehaviour 
{
	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "NPC")
		{
			Debug.Log("WIDZE NPC");
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowNPCBars : MonoBehaviour 
{ 
	[SerializeField] private bool showNPCBars;

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "NPC" && showNPCBars)
		{
			other.SendMessage("SetBars", true, SendMessageOptions.DontRequireReceiver);
		}
	}

	private void OnTriggerExit(Collider other) {
		if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "NPC" && showNPCBars)
		{
			other.SendMessage("SetBars", false, SendMessageOptions.DontRequireReceiver);
		}
	}
}


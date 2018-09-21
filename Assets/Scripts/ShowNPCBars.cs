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

		if(other.gameObject.tag == "Item")
		{
			Debug.Log("WIDZĘ ITEM");
		}
	}

	private void OnTriggerExit(Collider other) {
		if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "NPC" && showNPCBars)
		{
			other.SendMessage("SetBars", false, SendMessageOptions.DontRequireReceiver);
		}

		if(other.gameObject.tag == "Item")
		{
			Debug.Log("JUŻ NIE WIDZE ITEMU");
		}
	}
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEnemyBars : MonoBehaviour 
{
	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Enemy")
		{
			other.SendMessage("SetBars", true, SendMessageOptions.DontRequireReceiver);
		}
	}

	private void OnTriggerExit(Collider other) {
		if(other.gameObject.tag == "Enemy")
		{
			other.SendMessage("SetBars", false, SendMessageOptions.DontRequireReceiver);
		}
	}
}

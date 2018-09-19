using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Door : MonoBehaviour 
{
	public float speed;
	public KeyCode openningKey;
	public Vector3 endPosition;
	Vector3 startPosition;
	GameObject doors;
	bool isOpen = false;
	Animator animator;

	private void Awake() 
	{
		doors = gameObject;
		startPosition = doors.transform.position;
		animator = doors.GetComponent<Animator>();	
	}

	private void OnTriggerStay(Collider other) 
	{
		if(other.CompareTag("Player"))
		{
			other.gameObject.SendMessage("ShowDoorNotification", SendMessageOptions.DontRequireReceiver);
			if(Input.GetKeyDown(openningKey))
			{
				StartCoroutine(SlideDoors());
			}
		} /*else if(other.CompareTag("Enemy"))
		{
			StartCoroutine(SlideDoors());
		} */
	}

	private void OnTriggerExit(Collider other) 
	{
		other.gameObject.SendMessage("CleanNotifications", SendMessageOptions.DontRequireReceiver);
	}

	IEnumerator SlideDoors()
	{
		Vector3 currentPos = doors.transform.position;
		Vector3 destination = isOpen ? startPosition : endPosition;
		isOpen = !isOpen;
		float t = 0f;
		while(t < 1)
		{
			t += Time.deltaTime * speed;
			doors.transform.position = Vector3.Lerp(currentPos, destination, t);
			yield return null;
		}
	}
}

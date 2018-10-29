using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Door : MonoBehaviour 
{
	public float speed;
	public Vector3 endPosition;
	Vector3 startPosition;
	GameObject doors;
	[SerializeField] private bool isOpen = false;
	Animator animator;

	private void Awake() 
	{
		doors = gameObject;
		startPosition = doors.transform.position;
		animator = doors.GetComponent<Animator>();	
	}

	private void OnTriggerStay(Collider other) 
	{
		if(other.gameObject.tag == "Player")
		{
			StartCoroutine("SlideDoors", true);
		} 
	}

	private void OnTriggerExit(Collider other) 
	{
		if(other.gameObject.tag == "Player")
		{
			StartCoroutine("SlideDoors", false);
		}	
	}


	IEnumerator SlideDoors(bool open)
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

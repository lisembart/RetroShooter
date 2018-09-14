using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoor : MonoBehaviour 
{
	public Transform lockedDorPos;
	public Transform openDorPos;
	public float distanceToOpen;
	public float distanceToClose;
	public float movementSpeed;
	private bool open;
	private bool close;

	void Start () 
	{
		
	}
	

	void Update () 
	{
		Vector3 openDorPosVector = new Vector3(transform.position.x, transform.position.y, transform.position.z);

		distanceToOpen = Vector3.Distance(transform.position, openDorPosVector);
		distanceToClose = Vector3.Distance(transform.position, lockedDorPos.transform.position);

		if(open)
		{
			if(distanceToOpen <= 0.2)
			{
            	transform.position = Vector3.MoveTowards(transform.position, openDorPos.position, movementSpeed * Time.deltaTime);
			} 
		}

		if(close)
		{
			if(distanceToClose >= 0.2)
			{
				transform.position = Vector3.MoveTowards(transform.position, lockedDorPos.transform.position, movementSpeed * Time.deltaTime);
			}
		}
	}

	private void OnTriggerEnter(Collider other) 
	{
	    if(other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
        {
			close = false;
			open = true;
        }	
	}

	private void OnTriggerExit(Collider other) 
	{
		if(other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
		{
			open = false;
			close = true;
		}
	}
}

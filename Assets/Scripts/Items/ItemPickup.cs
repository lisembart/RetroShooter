using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour 
{
	Item item;

	void Start () 
	{
		
	}
	

	void Update () 
	{
		
	}

	private void OnTriggerEnter(Collider other) 
	{
		if(other.gameObject.tag == "Player")
		{
			Debug.Log("Player pickup somethink");
			item = gameObject.GetComponentInParent<Item>();
			item.PickUp();
		}	
	}
}

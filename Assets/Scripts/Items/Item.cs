using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour 
{
	[SerializeField] protected string itemName;
	[SerializeField] private bool collectibleItem;

	void Start () 
	{
		
	}
	
	public string GetItemName()
	{
		return itemName;
	}

	public virtual void PickUp()
	{

	}

	public virtual void Action()
	{

	}
	
	private void OnTriggerEnter(Collider other) 
	{
		if(other.gameObject.tag == "Player")
		{
			other.gameObject.SendMessage("ShowItemNotification", itemName, SendMessageOptions.DontRequireReceiver);
		}	
	}

	private void OnTriggerExit(Collider other) 
	{
		if(other.gameObject.tag == "Player")
		{
			other.gameObject.SendMessage("CleanNotifications", SendMessageOptions.DontRequireReceiver);
		}	
	}
}

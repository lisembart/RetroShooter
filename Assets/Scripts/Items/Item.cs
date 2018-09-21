using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item : MonoBehaviour 
{
	[SerializeField] protected string itemName;
	[SerializeField] private bool collectibleItem;
	[SerializeField] private Text itemNameText;

	void Start () 
	{
		
	}
	
	public string GetItemName()
	{
		return itemName;
	}

	void Update () 
	{
		itemNameText.text = itemName;
	}

	public void PickUp()
	{
		if(collectibleItem)
		{
			Debug.Log("Collecting item");
			Destroy(gameObject);
		} else 
		{
			Action();
		}
	}

	public virtual void Action()
	{

	}

	private void OnTriggerEnter(Collider other) 
	{
		if(other.gameObject.tag == "Player")
		{
			PickUp();
		}
	}
}

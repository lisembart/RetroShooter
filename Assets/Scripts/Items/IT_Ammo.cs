using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IT_Ammo : Item
{
	public int ammoToAdd; 

	public override void PickUp()
	{
		Debug.Log("Collecting ammo");
		Destroy(gameObject);
	}
}

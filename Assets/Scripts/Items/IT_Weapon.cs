using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IT_Weapon : Item
{
	[SerializeField] private Items_Weapons weaponType;

	private void OnTriggerStay(Collider other) 
	{
		if(other.gameObject.name == "Player")
		{
			WeaponSwitch weaponSwitch = other.gameObject.GetComponentInChildren<WeaponSwitch>();
			weaponSwitch.SendMessage("AddWeapon", weaponType);
			FindObjectOfType<ShowItemBars>().CleanText();
			Destroy(gameObject);
		}	
	}
	
	void Update () 
	{
		
	}
}

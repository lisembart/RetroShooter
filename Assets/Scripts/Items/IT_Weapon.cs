using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IT_Weapon : MonoBehaviour 
{
	[SerializeField] private Items_Weapons weaponType;

	private void OnTriggerStay(Collider other) 
	{
		if(other.gameObject.tag == "Player")
		{
			WeaponSwitch weaponSwitch = other.gameObject.GetComponentInChildren<WeaponSwitch>();
			weaponSwitch.SendMessage("AddWeapon", weaponType);
			Destroy(gameObject);
		}	
	}
	
	void Update () 
	{
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowItemBars : MonoBehaviour 
{
	public Text nameText;
	Item item;
	NPC npc;

	private void OnTriggerEnter(Collider col) 
	{
		if(col.gameObject.tag == "Item")
		{
			Debug.Log("MAM JAKIŚ AJTEM");
			item = col.gameObject.GetComponent<Item>();
			nameText.text = item.GetItemName();
		} 

		if(col.gameObject.tag == "NPC")
		{
			Debug.Log("MAM JAKIEGOŚ NPCTA");
			npc = col.gameObject.GetComponent<NPC>();
			nameText.text = npc.GetNpcName();
		}
	}

	private void OnTriggerExit(Collider col) 
	{
		if(col.gameObject.tag == "NPC")
		{
			Debug.Log("NIE MA JUŻ NPCA");
			npc = null;
			CleanText();
		}

		if(col.gameObject.tag == "Item")
		{
			Debug.Log("NIE MA JUŻ ITEMA");			
			item = null;
			CleanText();
		}
	}

	void Update()
	{

	}

	public void CleanText()
	{
		Debug.Log("CLEANUJE TEXT");
		nameText.text = " ";
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedMaterials : MonoBehaviour 
{
	public float timeBetweenMaterials;
	public Material[] materials;
	private Renderer renderer;

	void Start () 
	{
		renderer = GetComponent<Renderer>();
		StartCoroutine("StartAnimation");
	}

	IEnumerator StartAnimation()
	{
		int currentMaterial = 0;

		for(;;)
		{	
			renderer.material = materials[currentMaterial];
			yield return new WaitForSeconds(timeBetweenMaterials);
			currentMaterial++;
			if(currentMaterial >= materials.Length)
			{
				currentMaterial = 0;
			} 
		}
	}
}

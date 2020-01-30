using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawns : MonoBehaviour 
{
	private string ActiveFruit;
	private int FruitsCollected = 0;
	private static int Level;
	
	
	void Awake () 
	{
		Level = Pickup.getLevel();

		if (Level == 1)     {ActiveFruit = "Cherry"; }
		else if(Level == 2) {ActiveFruit = "Strawberry";}
		else if(Level == 3) {ActiveFruit = "Orange";}
		else if(Level == 4) {ActiveFruit = "Apple";}
		else if(Level == 5) {ActiveFruit = "Melon";}
		else if(Level == 6) {ActiveFruit = "Galaxian";}
		else if(Level == 7) {ActiveFruit = "Bell";}
		else if(Level > 7 ) {ActiveFruit = "Key";}

		GameObject[] GameObjectArray = GameObject.FindGameObjectsWithTag("Fruit");
		int i = 0; 
		foreach (GameObject Fruit in GameObjectArray)
		{
			i++;
			if(Fruit.name != ActiveFruit)
			{
				Fruit.SetActive(false);
			}
		}
		Invoke("SpawnActiveFruit", 10f);
	}
	
	void SpawnActiveFruit()
	{

		if(FruitsCollected < 2)
		{
			FruitsCollected++;
			transform.position += Vector3.up * 8.0f;
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			transform.position += Vector3.down * 8.0f;
			Invoke("SpawnActiveFruit", 10f);
		}
	}
}

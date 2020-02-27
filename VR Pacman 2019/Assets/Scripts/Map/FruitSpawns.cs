using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawns : MonoBehaviour
{
	private string ActiveFruit;
	private int FruitsCollected = 0;
	private static int Level;

	void Awake()
	{
		Level = PickUpFruits.getLevel();

		switch (Level)
		{
			case 1:
				ActiveFruit = "Cherry";
				break;
			case 2:
				ActiveFruit = "Strawberry";
				break;
			case 3:
				ActiveFruit = "Orange";
				break;
			case 4:
				ActiveFruit = "Apple";
				break;
			case 5:
				ActiveFruit = "Melon";
				break;
			case 6:
				ActiveFruit = "Galaxian";
				break;
			case 7:
				ActiveFruit = "Bell";
				break;
			default:
				ActiveFruit = "Key";
				break;
		}
		GameObject[] GameObjectArray = GameObject.FindGameObjectsWithTag("Fruit");
		int i = 0;
		foreach (GameObject Fruit in GameObjectArray)
		{
			i++;
			if (Fruit.name != ActiveFruit)
			{
				Fruit.SetActive(false);
			}
		}
		Invoke("SpawnActiveFruit", 30f);
	}

	void SpawnActiveFruit()
	{

		if (FruitsCollected < 2)
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
			Invoke("SpawnActiveFruit", 30f);
		}
	}
}
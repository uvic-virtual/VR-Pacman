using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawns : MonoBehaviour {
	public string ActiveFruit;
	private static int Level;
	GameObject ActiveFruitObject; 
	void Awake () {
		Level = Pickup.getLevel();

		if (Level == 1) { ActiveFruit = "Cherry"; }
		else if(Level == 2) {ActiveFruit = "Strawberry";}
		else if(Level == 3) {ActiveFruit = "Orange";}
		else if(Level == 4) {ActiveFruit = "Apple";}
		else if(Level == 5) {ActiveFruit = "Melon";}
		else if(Level == 6) {ActiveFruit = "Galaxian";}
		else if(Level == 7) {ActiveFruit = "Bell";}
		else if(Level > 7) {ActiveFruit = "Key";}

		GameObject[] GameObjectArray = GameObject.FindGameObjectsWithTag("Fruit");
		int i = 0; 
		foreach (GameObject Fruit in GameObjectArray)
		{
			Fruit.SetActive(false);			
			i++;
		}




	}
}

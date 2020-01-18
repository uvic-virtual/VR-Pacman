using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawns : MonoBehaviour {
	public string activeFruit;
	private static int Level;
	void Awake () {
		Level = Pickup.getLevel();

		if (Level == 1) { activeFruit = "Cherry"; }
		else if(Level == 2) {activeFruit = "Strawberry";}
		else if(Level == 3) {activeFruit = "Orange";}
		else if(Level == 4) {activeFruit = "Apple";}
		else if(Level == 5) {activeFruit = "Melon";}
		else if(Level == 6) {activeFruit = "Galaxian";}
		else if(Level == 7) {activeFruit = "Bell";}
		else if(Level > 7) {activeFruit = "Key";}

		GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("Fruit");
		int i = 0; 
		foreach (GameObject Fruit in gameObjectArray)
		{
			if(gameObjectArray[i].name != activeFruit)
			{
				Fruit.SetActive(false);
			}
			i++;
		}




	}
}

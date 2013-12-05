using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharSelect : MonoBehaviour {

	public List<Transform> charSpawnLocations;

	public Color highlighter;
	

	// The characters prefabs to pick
	public Transform[] charsPrefabs;
	
	// The game objects created to be showed on screen
	private GameObject[] chars;
	
	// The index of the current character
	private int currentChar = 0;
	
	void Start() {
		LoadSpawnLocations();
		// We initialize the chars array
		chars = new GameObject[charsPrefabs.Length];
		
		// We create game objects based on characters prefabs
		int index = 0;
		foreach (Transform t in charsPrefabs)
		{
			chars[index++] = GameObject.Instantiate(t.gameObject, charSpawnLocations[index - 1].position, Quaternion.identity) as GameObject;
			print (index);
		}
	}
	
	void OnGUI() {
		GameObject selectedChar = chars[currentChar];

		// Here we create a button to choose a next char
		if (GUI.Button(new Rect(10, (Screen.height - 50) / 2, 100, 50), "Previous")) {
			currentChar--;
			//prevChar.renderer.material.color = Color.white;

			if (currentChar < 0) {
				currentChar = 0;
			}
		}
		
		// Now we create a button to choose a previous char
		if (GUI.Button(new Rect(Screen.width - 100 - 10, (Screen.height - 50) / 2, 100, 50), "Next")) {
			currentChar++;
			//prevChar.renderer.material.color = Color.white;
			
			if (currentChar >= chars.Length) {
				currentChar = chars.Length - 1;
			}
		}
		
		// Shows a label with the name of the selected character
		//GameObject selectedChar = chars[currentChar];
		string labelChar = selectedChar.name;
		GUI.Label(new Rect((Screen.width - 100) / 2, 20, 100, 50), labelChar);

		// The index of the middle character
		int middleTopIndex = currentChar + 1;        
		// The index of the left character
		int leftTopIndex = currentChar;
		// The index of the right character
		int rightTopIndex = currentChar - 1;


		// For each character we set the position based on the current index
		for (int index = 0; index < chars.Length; index++)
		{
			Renderer rend = chars[index].renderer;


			if (index == leftTopIndex)
			{
				selectedChar.renderer.material.color = highlighter;		
			}
			else if (index == middleTopIndex)
			{
				selectedChar.renderer.material.color = highlighter;				
			}
			else if (index == rightTopIndex)
			{
				selectedChar.renderer.material.color = highlighter;				
			}
		}
	}

	public List<Transform> LoadSpawnLocations()
	{
		Transform[] tempSpawnLocs = GetComponentsInChildren<Transform>(); // Recieves all the spawnlocations from the Holder gameobject
		charSpawnLocations.AddRange(tempSpawnLocs); // Counts the spawn locations and adds cartSpawnLocations to the list 
		charSpawnLocations.Remove(transform); // Removes the Holder gamobject from the list
		return charSpawnLocations;
	}
}

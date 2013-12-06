using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharSelect : MonoBehaviour { 

	public Color selected;
	public Color notSelected;

	private float previousDpadAxis; // Previous D-pad input 
	
	public Transform[] charsPrefabs; // The characters prefabs to pick

	public List<Transform> charSpawnLocations; // Character spawnlocs

	public GameObject[] chars; // The game objects created to be showed on screen

	public int currentChar = 0; // The index of the current character
	
	public bool curSelected = false;



	void Start() {
		LoadSpawnLocations();
		// Initialize the chars array


		SpawnCharacters();

	}
	
	void Update()
	{
		ScrollVertically();
		//ScrollHorizontally(); // Needs more work
		SetColor();
	}

	void OnGUI() {
		GameObject selectedChar = chars[currentChar];
		
		// Shows a label with the name of the selected character
		string labelChar = selectedChar.name;
		GUI.Label(new Rect((Screen.width - 100) / 2, 20, 100, 50), labelChar);
	}


	public void SetColor()
	{	
		for (int i = 0; i < chars.Length; i++)
		{
			if (i == currentChar){
				
				chars[i].renderer.material.color = selected;
				
			}else{
				chars[i].renderer.material.color = notSelected;
			}
		}
	}
	
	void ScrollVertically()
	{
		if(Input.GetAxis ("DPADVert1") != previousDpadAxis )
		{
			SetColor();

			previousDpadAxis = Input.GetAxis ("DPADVert1");

			currentChar += (int)previousDpadAxis;

			currentChar = Mathf.Clamp(currentChar, 0, chars.Length - 1);
		}
	}
	
	void ScrollHorizontally()
	{
		//GameObject selectedChar = chars[currentChar];
		
		if(Input.GetAxis ("DPADHor1") != previousDpadAxis)
		{
			previousDpadAxis = Input.GetAxis ("DPADHor1");
			Debug.Log(Input.GetAxis ("DPADHor1"));
			
			currentChar += 3;
			
			currentChar = Mathf.Clamp(currentChar, 0, chars.Length - 1);
		}
	}
	
	public List<Transform> LoadSpawnLocations()
	{
		Transform[] tempSpawnLocs = GetComponentsInChildren<Transform>(); // Recieves all the spawnlocations from the Holder gameobject
		charSpawnLocations.AddRange(tempSpawnLocs); // Counts the spawn locations and adds cartSpawnLocations to the list 
		charSpawnLocations.Remove(transform); // Removes the Holder gamobject from the list
		return charSpawnLocations;
	}

	void SpawnCharacters()
	{
		chars = new GameObject[charsPrefabs.Length];
		// Create game objects based on characters prefabs
		int index = 0;
		foreach (Transform t in charsPrefabs)
		{
			chars[index++] = GameObject.Instantiate(t.gameObject, charSpawnLocations[index - 1].position, Quaternion.identity) as GameObject;
			//print (index);
		}
	}
}

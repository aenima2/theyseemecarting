using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharSelectCopy : MonoBehaviour { 

	public Color highlighter;
	public Color notSelected;

	private float previousDpadAxis; // Previous D-pad input 
	
	public Transform[] charsPrefabs; // The characters prefabs to pick

	public List<Transform> charSpawnLocations; // Character spawnlocs

	private GameObject[] chars; // The game objects created to be showed on screen

	private int currentChar = 0; // The index of the current character

	//private int previousChar = -1;

	private bool curSelected = false;

	
	void Start() {
		LoadSpawnLocations();
		// We initialize the chars array
		chars = new GameObject[charsPrefabs.Length];

		notSelected = Color.white;


		// We create game objects based on characters prefabs
		int index = 0;
		foreach (Transform t in charsPrefabs)
		{
			chars[index++] = GameObject.Instantiate(t.gameObject, charSpawnLocations[index - 1].position, Quaternion.identity) as GameObject;
			//print (index);
		}
	}

	void Update()
	{
		ScrollVertically();

		setColor ();
		//ScrollHorizontally(); // Needs more work

		//GameObject selectedChar = chars[currentChar];

		/*for (int i = 0; i < chars.Length; i++)
		{
			if(i = currentChar)
			{
				selectedChar.renderer.material.color = highlighter;
			}
		}*/
		//notSelected = chars[notSelected - currentChar]

	}
	
	
	
	public void setColor(){
		
		for (int i = 0; i < chars.Length; i++) {
			
			if (i == currentChar){
				
				chars[i].renderer.material.color = highlighter;
				
			}else{
				chars[i].renderer.material.color = notSelected;
			}
			
		}

	}

	void ScrollVertically()
	{
		GameObject selectedChar = chars[currentChar];

		if(Input.GetAxis ("DPADVert1") != previousDpadAxis )
		{


			previousDpadAxis = Input.GetAxis ("DPADVert1");

			currentChar += (int)previousDpadAxis;

			currentChar = Mathf.Clamp(currentChar, 0, chars.Length - 1);
		}
	}

	void ScrollHorizontally()
	{
		GameObject selectedChar = chars[currentChar];
		
		if(Input.GetAxis ("DPADHor1") != previousDpadAxis)
		{
			previousDpadAxis = Input.GetAxis ("DPADHor1");
			Debug.Log(Input.GetAxis ("DPADHor1"));
			
			currentChar += 3;
			
			currentChar = Mathf.Clamp(currentChar, 0, chars.Length - 1);
		}
	}


 


	void OnGUI() {
		GameObject selectedChar = chars[currentChar];

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

		/*
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
		}*/
	}

	public List<Transform> LoadSpawnLocations()
	{
		Transform[] tempSpawnLocs = GetComponentsInChildren<Transform>(); // Recieves all the spawnlocations from the Holder gameobject
		charSpawnLocations.AddRange(tempSpawnLocs); // Counts the spawn locations and adds cartSpawnLocations to the list 
		charSpawnLocations.Remove(transform); // Removes the Holder gamobject from the list
		return charSpawnLocations;
	}
}

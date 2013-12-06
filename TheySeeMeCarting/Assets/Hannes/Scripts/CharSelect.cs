using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharSelect : MonoBehaviour { 

	public Color selected;
	public Color notSelected;

	private float previousDpadAxis; // Previous D-pad input 
	private float previousDpadAxisY;
	
	public Transform[] charsPrefabs; // The characters prefabs to pick

	public List<Transform> charSpawnLocations; // Character spawnlocs

	public GameObject[] chars; // The game objects created to be showed on screen

	public int currentChar = 0; // The index of the current character

	[System.NonSerialized] // Don't display in inspector
	public bool hasSelected = false;

	public bool startGameFailMsg = false;




	void Start()
	{
		LoadSpawnLocations();
		SpawnSelectableCharacters();
		chars[currentChar].renderer.material.color = selected; // Highlight the first character
	}
	
	void Update()
	{
		if(Input.GetButtonDown("Select1"))
		{
			SelectCharacter();
		}

		if(Input.GetButtonDown("DeSelect1"))
		{
			DeSelectCharacter();
		}

		if(hasSelected == false)
		{
			if(Input.GetAxis ("DPADVert1") != previousDpadAxis )
			{
				ScrollVertically();
			}
			if(Input.GetAxis ("DPADHor1") != previousDpadAxis)
			{
				ScrollHorizontally(); // Doesn't work
			}
		}

		if(Input.GetButtonDown("StartAll"))
		{
			TryStartGame();
		}
	}

	void OnGUI() {
		GameObject selectedChar = chars[currentChar];
		
		// Shows a label with the name of the selected character
		string labelChar = selectedChar.name;
		GUI.Label(new Rect((Screen.width - 100) / 2, 20, 100, 50), labelChar);


		// All players must select a character Msg
		if(startGameFailMsg == true)
		{
			Rect playersMustSelect = new Rect(0.3f, 0.2f, 0.4f, 0.2f);
			GUI.skin.label.alignment = TextAnchor.MiddleCenter; // Centralizes the text
			GUI.Label (new Rect(NormalizeRect(playersMustSelect)), "All players must select a character"); // Displays message
		}
	}
	
	public void SetColor()
	{	
		for (int i = 0; i < chars.Length; i++)
		{
			if (i == currentChar)
			{
				
				chars[i].renderer.material.color = selected;
				
			}
			else
			{
				chars[i].renderer.material.color = notSelected;
			}
		}
	}
	
	public void ScrollVertically()
	{
		SetColor();

		previousDpadAxis = Input.GetAxis ("DPADVert1");

		currentChar += (int)previousDpadAxis;
		currentChar = Mathf.Clamp(currentChar, 0, chars.Length - 1);
	}

	// Not finished
	public void ScrollHorizontally()
	{
		SetColor();

		//previousDpadAxisY = Input.GetAxis ("DPADHor1");
		Debug.Log(Input.GetAxis ("DPADHor1"));

		if(currentChar == 0)
		{
			currentChar += 3;
			currentChar = Mathf.Clamp(currentChar, 0, chars.Length - 1);
			print ("horiz");
		}

		//currentChar += 3;
		//currentChar = Mathf.Clamp(currentChar, 0, chars.Length - 1);
	}
	
	public List<Transform> LoadSpawnLocations()
	{
		Transform[] tempSpawnLocs = GetComponentsInChildren<Transform>(); // Recieves all the spawnlocations from the Holder gameobject
		charSpawnLocations.AddRange(tempSpawnLocs); // Counts the spawn locations and adds cartSpawnLocations to the list 
		charSpawnLocations.Remove(transform); // Removes the Holder gamobject from the list
		return charSpawnLocations;
	}

	// Start from here Hannes
	void SpawnSelectableCharacters()
	{
		/*
		Vector2 hest = new Vector2;

		// use this instead of the previous criss
		for(int y = 0; y < Vector2.y; x++) // loop through all x-rows
		{
			for(int x = 0; x < Vector2.x; y++) // fill up first x-row
			{
				Instantiate(new Vector2(x,y); // instantiate the criss
			}
		}*/

		chars = new GameObject[charsPrefabs.Length];
		// Create game objects based on characters prefabs
		int index = 0;
		foreach (Transform t in charsPrefabs)
		{
			chars[index++] = GameObject.Instantiate(t.gameObject, charSpawnLocations[index - 1].position, Quaternion.identity) as GameObject;
			//print (index);
		}
	}

	public void SelectCharacter()
	{
		hasSelected = true;
	}

	public void DeSelectCharacter()
	{
		hasSelected = false;
	}

	public void TryStartGame()
	{
		if(hasSelected == true)
		{
			StartGame();
		}
		else
		{
			if(startGameFailMsg)
			{
				startGameFailMsg = false;
			}
			else
			{
				startGameFailMsg = true;
				StartCoroutine(Coroutine1(2f)); // Active 2 sec
			}
		}
	}

	void StartGame()
	{
		Application.LoadLevel("testlevel");
	}

	

	IEnumerator Coroutine1(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		startGameFailMsg = false;
	}


	/*
	 * private Rect NormalizeRect
	 * Normalizes the Rect in GUI so it stays on screen even when screen width and height changes
	 * 
	 */
	private Rect NormalizeRect(Rect r)
	{
		r.x *= Screen.width;		
		r.y *= Screen.height;
		
		r.width *= Screen.width;
		r.height *= Screen.height;
		
		return r;
	}
}

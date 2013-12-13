using UnityEngine;
using System.Collections;
using System.IO; // to be able to use file

public enum GameMode { Deathmatch, CTF, FFA, ControlPoints }

public class savedatainfileExample : MonoBehaviour {

	/*
	public GameMode currentGameMode;

	public GameObject[] cubes;

	public Transform cursor;

	string path;

	private int selectionID = 0;
	public int SelectionID // Property
	{
		get
		{
			return selectionID; // Get selectionID
		}
		set
		{
			selectionID = Mathf.Clamp(value, 0, cubes.Length - 1); // Clamp and Set selectionID
		}
	}




	public Transform transform
	{
		get
		{
			return GetComponent<Transform>();
		}
	}


	public Player player
	{
		get
		{
			return GetComponent<Player>();
		}
	}
	*/

	// Use this for initialization
	void Awake () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		/*
		switch(currentGameMode)
		{
		case GameMode.ControlPoints:
			//
			break;
		case GameMode.CTF:
			//
			break;
		case GameMode.Deathmatch:
			//
			break;
		default:
			print ("you are missing a gamemmode in the update loop");
		}


		if(currentGameMode = GameMode.CTF)
		{
			print("SpawnFlag");
		}
		else if(currentGameMode = GameMode.ControlPoints)
		{
			print ("bla");
		}
		*/



		/*
		if(Input.GetMouseButtonDown(0))
		{
			Instantiate(cubes[selectionID], Vector3.zero, Quaternion.identity);
		}

		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			SelectionID++;
		}

		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			SelectionID--;
		}

		if(Input.GetKeyDown(KeyCode.S))
		{
			Save();
		}
		
		if(Input.GetKeyDown(KeyCode.L))
		{
			Load();
		}
		*/
	}

	/*
	void Save()
	{
		string s = "";

		Cube[] cubes = FindObjectsOfType<Cube>();

		foreach(Cube cube in cubes)
		{
			s += cube.Serialize() + "\n";
		}

		path = Application.dataPath + "/" + "Level.txt";

		File.WriteAllText(path, s);

	}

	void Load()
	{
		string[] lines = File.ReadAllLines(path);

		foreach(string line in lines)
		{
			DeSerialize(line);
		}
	}


	void DeSerialize(string line)
	{
		string[] pieces = line.Split(',');

		Vector3 spawnPos = Vector3.zero;

		spawnPos.x = float.Parse(pieces[0]);
		spawnPos.y = float.Parse(pieces[1]);
		spawnPos.z = float.Parse(pieces[2]);

		cubeType = int.Parse(pieces[3]);

		Instantiate(cubes[cubeType], spawnPos, Quaternion.identity);
	}
	*/



}

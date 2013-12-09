using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArrayTest : MonoBehaviour {

	public int spawn;
	public int rows;
	public int cols;
	public GameObject gemObject;
	public GameObject [][] pieces;
	public Object [] gems;
	

	// Use this for initialization
	void Start () {

		//Initializing variables
		rows = 3;
		cols = 2;
		spawn = 6;
		pieces = new GameObject[rows][];

		
		//load's gems from the resources Gem folder to this object array
		//gems = Resources.LoadAll("Gems", typeof(GameObject));        
		
		for (int i = 0; i < gems.Length; i++)
			Debug.Log("gems #" + i + "is: " + gems[i].name);
		
		for (int i=0; i < rows; i++)
		{
			pieces[i] = new GameObject[rows];
			for (int j = 0; j < cols; j++)
			{
				pieces[i][j] = (GameObject) Instantiate (gems[i], new Vector2(i,j), Quaternion.identity);
			}
		}
	}
}

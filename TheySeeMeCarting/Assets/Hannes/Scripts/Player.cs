using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Player info
	public string playerName;

	// Cart handling
	public KeyCode forward;
	public KeyCode back;
	public KeyCode left;
	public KeyCode right;

	[System.NonSerialized]
	public Cart cart;

	public CartSpawner spawner;


	void Start ()
	{

	}
	
	void Update ()
	{
	
	}
}

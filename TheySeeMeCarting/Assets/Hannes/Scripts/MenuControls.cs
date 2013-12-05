using UnityEngine;
using System.Collections;

public class MenuControls : MonoBehaviour {

	public Player player;

	public KeyCode menuUp;
	public KeyCode menuDown;
	public KeyCode menuLeft;
	public KeyCode menuRight;
	public KeyCode menuSelect;

	public void KeySetup1()
	{
		menuUp = KeyCode.W;
		menuDown = KeyCode.S;
		menuLeft = KeyCode.A;
		menuRight = KeyCode.D;
	}

	public void KeySetup2()
	{
		menuUp = KeyCode.UpArrow;
		menuDown = KeyCode.DownArrow;
		menuLeft = KeyCode.LeftArrow;
		menuRight = KeyCode.RightArrow;
	}

}

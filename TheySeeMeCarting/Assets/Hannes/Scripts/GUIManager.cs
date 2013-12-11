using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {

	[HideInInspector]
	public bool activateP2 = false;
	[HideInInspector]
	public bool activateP3 = false;
	[HideInInspector]
	public bool activateP4 = false;

	[HideInInspector]
	public bool startGameFailMsg = false; // Controls if all players have chosen a character


	void OnGUI()
	{
		Player player = FindObjectOfType<Player>();
		CharSelect cs = FindObjectOfType<CharSelect>();

		// Checks which character is selected at the moment and display it in the window
		// Needs to be reworked due to problem with multiple players
		if(player != null)
		{
			GameObject selectedChar = cs.charPrefabs[(int)(player.currentChar.x * 2 + player.currentChar.y)];
			string labelChar = selectedChar.name; //Shows a label with the name of the selected character
			GUI.Label(new Rect((Screen.width - 100) / 2, 20, 100, 50), labelChar);
		}

		// Activate player 2 gui
		if(activateP2 == true)
		{
			Rect player2msg = new Rect(0.15f, 0.85f, 0.4f, 0.2f);
			GUI.skin.label.alignment = TextAnchor.MiddleCenter; // Centralizes the text
			GUI.Label (new Rect(NormalizeRect(player2msg)), "Player 2"); // Displays message
		}
		else
		{
			Rect activateP2msg = new Rect(0.15f, 0.85f, 0.4f, 0.2f);
			GUI.skin.label.alignment = TextAnchor.MiddleCenter; // Centralizes the text
			GUI.Label (new Rect(NormalizeRect(activateP2msg)), "Press start to join"); // Displays message
		}
		// Activate player 3 gui
		if(activateP3 == true)
		{
			Rect player2msg = new Rect(0.4f, 0.85f, 0.4f, 0.2f);
			GUI.skin.label.alignment = TextAnchor.MiddleCenter; // Centralizes the text
			GUI.Label (new Rect(NormalizeRect(player2msg)), "Player 3"); // Displays message
		}
		else
		{
			Rect activateP2msg = new Rect(0.4f, 0.85f, 0.4f, 0.2f);
			GUI.skin.label.alignment = TextAnchor.MiddleCenter; // Centralizes the text
			GUI.Label (new Rect(NormalizeRect(activateP2msg)), "Press start to join"); // Displays message
		}
		// Activate player 4 gui
		if(activateP4 == true)
		{
			Rect player2msg = new Rect(0.65f, 0.85f, 0.4f, 0.2f);
			GUI.skin.label.alignment = TextAnchor.MiddleCenter; // Centralizes the text
			GUI.Label (new Rect(NormalizeRect(player2msg)), "Player 4"); // Displays message
		}
		else
		{
			Rect activateP2msg = new Rect(0.65f, 0.85f, 0.4f, 0.2f);
			GUI.skin.label.alignment = TextAnchor.MiddleCenter; // Centralizes the text
			GUI.Label (new Rect(NormalizeRect(activateP2msg)), "Press start to join"); // Displays message
		}
		
		// All players must select a character before start message
		if(startGameFailMsg == true)
		{
			Rect playersMustSelect = new Rect(0.3f, 0.2f, 0.4f, 0.2f);
			GUI.skin.label.alignment = TextAnchor.MiddleCenter; // Centralizes the text
			GUI.Label (new Rect(NormalizeRect(playersMustSelect)), "All players must select a character"); // Displays message
		}
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


	/*
	 * IEnumerator Coroutine1
	 * Adds wait time for the Start game fail message
	 * 
	 */
	public IEnumerator Coroutine1(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		startGameFailMsg = false;
	}
}

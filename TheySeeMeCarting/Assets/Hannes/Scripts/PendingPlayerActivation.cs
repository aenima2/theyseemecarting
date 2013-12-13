using UnityEngine;
using System.Collections;

public class PendingPlayerActivation : MonoBehaviour {

	private bool joinedP2 = false;
	private bool joinedP3 = false;
	private bool joinedP4 = false;

	private CharSelect cs;
	private GameManager gm;
	private Player player;
	private GUIManager GUIMan;

	void Start()
	{
		cs = FindObjectOfType<CharSelect>();
		gm = FindObjectOfType<GameManager>();
		player = FindObjectOfType<Player>();
		GUIMan = FindObjectOfType<GUIManager>();
	}

	
	void Update()
	{
		if(player != null)
			ActivatePlayer();
	}


	void ActivatePlayer()
	{
		if(joinedP2 == false)
		{
			if(Input.GetButtonDown("360_StartButton1"))
			{
				GUIMan.activateP2 = true;
				gm.CreatePlayers();
				joinedP2 = true;
				if(cs.chars[0][1].renderer.material.color == cs.notSelectedColor)
					cs.chars[0][1].renderer.material.color = Color.red; // Marks the first character as player 2
				print("player 2 joined");
			}
		}
		if(joinedP3 == false)
		{
			if(Input.GetButtonDown("360_StartButton2")) // OBS not correct button, for testpurpose only
			{
				GUIMan.activateP3 = true;
				gm.CreatePlayers();
				joinedP3 = true;
				cs.chars[0][0].renderer.material.color = Color.green; // Marks the first character as player 2
				print("player 3 joined");
			}
		}
		if(joinedP3 == false)
		{
			if(Input.GetButtonDown("360_BackButton0")) // OBS not correct button, for testpurpose only
			{
				GUIMan.activateP4 = true;
				gm.CreatePlayers();
				joinedP4 = true;
				cs.chars[0][0].renderer.material.color = Color.yellow; // Marks the first character as player 2
				print("player 4 joined");
			}
		}
	}
}

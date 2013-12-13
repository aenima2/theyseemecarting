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
				if(cs.chars[0][0].renderer.material != cs.notSelectedMat) // If starting position is notSelectedMaterial
					cs.chars[0][0].renderer.material = gm.player2mat; // Color.red; // Marks the first character as player 2
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
				if(cs.chars[0][0].renderer.material != cs.notSelectedMat) // If starting position is notSelectedMaterial
					cs.chars[0][0].renderer.material = gm.player3mat; // Color.red; // Marks the first character as player 2
				print("player 3 joined");
			}
		}
		if(joinedP4 == false)
		{
			if(Input.GetButtonDown("360_StartButton3")) // OBS not correct button, for testpurpose only
			{
				GUIMan.activateP4 = true;
				gm.CreatePlayers();
				joinedP4 = true;
				if(cs.chars[0][0].renderer.material != cs.notSelectedMat) // If starting position is notSelectedMaterial
					cs.chars[0][0].renderer.material = gm.player4mat; // Color.red; // Marks the first character as player 2
				print("player 4 joined");
			}
		}
	}
}

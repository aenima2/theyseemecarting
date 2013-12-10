using UnityEngine;
using System.Collections;

public class PendingPlayerActivation : MonoBehaviour {

	private bool joinedP2 = false;
	private bool joinedP3 = false;
	private bool joinedP4 = false;

	//private CharSelect cs;
	//private GameManager gm;


	
	void Update ()
	{
		ActivatePlayer();
	}


	void ActivatePlayer()
	{
		CharSelect cs = FindObjectOfType<CharSelect>();
		GameManager gm = FindObjectOfType<GameManager>();
		Player player = FindObjectOfType<Player>();

		if(joinedP2 == false)
		{
			if(Input.GetButtonDown("360_StartButton2"))
			{
				cs.activateP2 = true;
				gm.CreatePlayers();
				joinedP2 = true;
				cs.chars[0][0].renderer.material.color = Color.red; // Marks the first character as player 2
				player.nop = 2;
				print("player 2 joined " + "\nNumber of players: " + player.nop);
			}
		}
	}
}

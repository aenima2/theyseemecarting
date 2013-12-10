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

		if(joinedP2 == false)
		{
			if(Input.GetButtonDown("360_StartButton2"))
			{
				cs.activateP2 = true;
				gm.CreatePlayers();
				joinedP2 = true;
				//.chars[0][0].renderer.material.color = Color.red;
				print("player 2 joined");
			}
		}
	}
}

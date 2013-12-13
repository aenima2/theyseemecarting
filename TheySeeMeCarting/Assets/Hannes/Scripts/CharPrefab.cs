using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharPrefab : MonoBehaviour {

	public bool selected = false;
	//[HideInInspector]
	public List<Player> players = new List<Player>(); // Adds a list of all possible players
	


	public void Select(Player p)
	{
		if(!players.Contains(p) )
		{
			if(selected == false) // Only select a player if it hasn't been selected by another player
			{
				players.Add(p);
				selected = true;
			}
		}
	}
	
	public void DeSelect(Player p)
	{
		if(players.Contains(p) )
		{
			players.Remove(p);
			selected = false;
		}
	}
}

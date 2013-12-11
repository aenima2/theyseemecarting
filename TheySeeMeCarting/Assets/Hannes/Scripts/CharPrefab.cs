using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharPrefab : MonoBehaviour {

	[HideInInspector]
	public List<Player> players = new List<Player>(); // Adds a list of all possible players

	
	public void Select(Player p)
	{
		if(!players.Contains(p) )
		{
			players.Add(p);
		}
	}
	
	public void DeSelect(Player p)
	{
		if(players.Contains(p) )
		{
			players.Remove(p);
		}
	}
}

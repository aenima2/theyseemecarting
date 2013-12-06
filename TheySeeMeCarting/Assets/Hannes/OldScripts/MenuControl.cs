using UnityEngine;
using System.Collections;

public class MenuControl : MonoBehaviour {

	public GUISkin skin;
	public float GUIPosX = 10f;
	public float GUIPosY = 10f;

	private int selection = 1;
	private int max = 3;


	void OnGUI()
	{
		GUI.skin = skin;

		if(selection == 1)
		{
			// GUI color(
			GUI.Label(new Rect(100, 100, 100, 100), "Attack<-");
			GUI.Label(new Rect(100, 110, 100, 100), "Hest");
			GUI.Label(new Rect(100, 120, 100, 100), "Items");
		}

		if(selection == 2)
		{
			// GUI color(
			GUI.Label(new Rect(100, 100, 100, 100), "Attack");
			GUI.Label(new Rect(100, 110, 100, 100), "Hest<-");
			GUI.Label(new Rect(100, 120, 100, 100), "Items");
		}

		if(selection == 3)
		{
			// GUI color(
			GUI.Label(new Rect(100, 100, 100, 100), "Attack");
			GUI.Label(new Rect(100, 110, 100, 100), "Hest");
			GUI.Label(new Rect(100, 120, 100, 100), "Items<-");
		}
	}

	void Update()
	{
		Handling();
	}


	void Handling()
	{
		if(Input.GetKeyDown(KeyCode.S))
		{
			selection += 1;
			print ("you've selected " + selection);
		}
		
		if(Input.GetKeyDown(KeyCode.W))
		{
			selection -= 1;
			print ("you've selected " + selection);
		}
		
		selection = Mathf.Clamp(selection, 1, max);
	}






}
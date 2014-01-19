using UnityEngine;
using System.Collections;

public class MainMenuControls : MonoBehaviour {

	public GameObject option1;
	public GameObject option2;
	public GameObject option3;

	private GameObject[] menu;
	private GameObject selection;
	private int selectionNum = 0;

	/*
	void Start()
	{
		menu.(option1);
		menu.push(option2);
		menu.push(option3);
		
		selection = menu[selectionNum];
		selection.renderer.material.color = Color.blue;
	}
	
	function Update(){
		if(Input.GetAxis("Vertical"))
			selection.renderer.material.color = Color.white;
		//change selectionNum
		//check to make sure the selection is not outside of the array
		selection = menu[selectionNum];
		//change color of selection
	}
	*/
}

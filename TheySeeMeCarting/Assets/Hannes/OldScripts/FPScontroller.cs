using UnityEngine;
using System.Collections;

public class FPScontroller : MonoBehaviour {

	CharacterController cc;

	public float movementSpeed;

	public float mouseSensitivity;

	public Transform cameraTf;


	void Awake()
	{
		cc = GetComponent<CharacterController>();
	}

	void Update ()
	{
		// locks/unlocks mouse in screen
		if(Input.GetMouseButton(0))
		{
			Screen.lockCursor = true;
			DoThingAfterTwoSeconds();
		}
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Screen.lockCursor = false;
		}


		CharacterMovement();
		CharacterMouseLook();
	}


	void DoThingAfterTwoSeconds()
	{
		StartCoroutine(MyWaitingCor());
	}

	IEnumerator MyWaitingCor()
	{
		Debug.Log ("before");
		yield return null; // waits one frame
		yield return StartCoroutine(OtherCor());
		Debug.Log ("after");
		yield break; // leaves the coroutine
	}

	IEnumerator OtherCor(/*float waitTime*/)
	{
		print ("before2");
		yield return new WaitForSeconds(5f /*waitTime*/);
		print ("after2");
	}


	void CharacterMovement()
	{
		Vector3 vel = Vector3.zero;
		
		if(Input.GetKey(KeyCode.W))
		{
			vel += transform.forward;
		}
		if(Input.GetKey(KeyCode.S))
		{
			vel -= transform.forward;
		}
		if(Input.GetKey(KeyCode.A))
		{
			vel -= transform.right;
		}
		if(Input.GetKey(KeyCode.D))
		{
			vel += transform.right;
		}
		
		cc.Move(vel * movementSpeed * Time.deltaTime);
	}

	void CharacterMouseLook()
	{
		if(!Screen.lockCursor) // if mousecursor isn't locked in the screen don't move the cam
			return;
		// Up/Down
		cameraTf.Rotate(-Input.GetAxis("Mouse Y") * mouseSensitivity, 0f, 0f);
		// Left/Right
		transform.Rotate(0f, Input.GetAxis("Mouse X") * mouseSensitivity, 0f);



	}


}

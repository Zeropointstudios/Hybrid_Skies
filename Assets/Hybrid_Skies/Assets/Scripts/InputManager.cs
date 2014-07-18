using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	//fields
	float clickTime; //counter used to distinguish between a tap click and a hold click
	bool holdingDown; //toggle for if mouse is being held down

	//events
	public delegate void HoldingDownDelegate();
	public static event HoldingDownDelegate OnHoldingDown;

	public delegate void ReleaseDelegate();
	public static event ReleaseDelegate OnRelease;

	// Update is called once per frame
	void FixedUpdate ()
	{

		//the following section handles the timing of tap and holding clicks
		holdingDown = Input.GetMouseButton (0) ? true : false;
		
		if (holdingDown) //adds to counter when click is held down
		{
			clickTime += 0.1f;
		}
		
		if (clickTime < 1.0f && holdingDown == false)
		{
			{
				clickTime = 0;
			}
		}
		
		if (clickTime >= 1.0f)
		{
			OnHoldingDown();

		}


		if (clickTime >= 1.0f && holdingDown == false)
		{
			OnRelease();
			clickTime = 0;
	
		}

	}

	void Start()
	{
		holdingDown = false;
		clickTime = 0;

	}
}
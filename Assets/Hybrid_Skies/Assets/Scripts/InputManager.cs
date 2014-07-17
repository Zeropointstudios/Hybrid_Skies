using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	//fields
	float clickTime; //counter used to distinguish between a tap click and a hold click
	bool holdingDown; //toggle for if mouse is being held down

	
	//delegates
	delegate void EnableSlowmoDelegate();
	EnableSlowmoDelegate enableSlowmoDelegate;

	delegate void DisableSlowmoDelegate();
	DisableSlowmoDelegate disableSlowmoDelegate;

//	delegate void FireSecondaryDelegate();
//	FireSecondaryDelegate fireSecondaryDelegate;
	

	// Update is called once per frame
	void FixedUpdate ()
	{
		holdingDown = Input.GetMouseButton (0) ? true : false;
		
		if (holdingDown) //adds to counter when click is held down
		{
			clickTime += 0.1f;
		}
		
		if (clickTime < 1.0f && holdingDown == false)
		{
			{
				clickTime = 0;
				holdingDown = false;
			}
		}
		
		if (clickTime >= 1.0f)
		{
			enableSlowmoDelegate();
			print ("enable");

		}

		if (clickTime >= 1.0f && holdingDown == false)
		{
			clickTime = 0;
			holdingDown = false;
			disableSlowmoDelegate();

		}

	}

	void Start()
	{
		holdingDown = false;
		clickTime = 0;
		enableSlowmoDelegate = TimeSlowdown.EnableSlowmo;
		disableSlowmoDelegate = TimeSlowdown.DisableSlowmo;
	}
}
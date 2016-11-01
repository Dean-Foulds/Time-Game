using UnityEngine;
using System.Collections;

public class TimeGame : MonoBehaviour {

	float startDelay = 3;
	float roundStartTime;
	int waitTime;
	bool roundStarted;


	// Use this for initialization
	void Start () {
		print("Press spacebar when you think alloted time is up.");
		Invoke ("SetNewRandomTime", startDelay);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && roundStarted) {
			InputReceived ();
				
		}
	}

	void InputReceived(){
			roundStarted = false;
			float playerWaitTime = Time.time - roundStartTime;
			float error = Mathf.Abs(waitTime - playerWaitTime);


			print ("You waited for " + playerWaitTime + " seconds.  That's " + error + " seconds off. " + GenerateMessage(error));
			Invoke ("SetNewRandomTime", startDelay);
		}


	string GenerateMessage(float error) {
		string message = "";
		if (error < 0.15f) {
			message = "Outstanding!";
		} else if (error < 0.75f) {
			message = "Exceeds expectations"; 
		} else if (error < 1.25f) {
			message = "Acceptable";
		} else if (error < 1.75f) {
			message = "Poor";
		} else {
			message = "Dreadful!";
		}
	}

	void SetNewRandomTime() {
		waitTime = Random.Range (2, 11);
		roundStartTime = Time.time;
		roundStarted = true;

		print (waitTime + " seconds.");
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour {

	#region lifecycle methods
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	#endregion

	private void OnTriggerEnter(Collider collider)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        // disable controls
        print("player dying");

        SendMessage("OnPlayerDeath");
    }
}
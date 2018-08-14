using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollisionHandler : MonoBehaviour
{

    [Tooltip("In seconds")][SerializeField] private float levelLoadDelay = 1f;
    [Tooltip("FX prefab on player")][SerializeField] private GameObject deathFx;

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
        deathFx.SetActive(true);
	    Invoke("ReloadScene", levelLoadDelay); // string reference
    }

    private void ReloadScene() // string reference
    {
        SceneManager.LoadScene(1);
    }

    private void StartDeathSequence()
	{
		// disable controls
		print("player dying");
		SendMessage("OnPlayerDeath");

	}
}
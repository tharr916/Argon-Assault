using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructor : MonoBehaviour
{
    [SerializeField] private float timeTillDestroyed = 5f;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, timeTillDestroyed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

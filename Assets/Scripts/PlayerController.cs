using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    // TODO work out why sometimes slow on first play of scene
	
	#region configuration

    [Header("General")]
	/// <summary>
	/// The speed the ship moves in the horizontal/X axis
	/// </summary>
	[Tooltip("In ms^-1")][SerializeField] private float xSpeed = 6f;
    /// <summary>
	/// The speed the ship moves in the vertical/Y
	/// </summary>
	[Tooltip("In ms^-1")][SerializeField] private float ySpeed = 5f;
	/// <summary>
	/// The range the ship can move to the sides of the screen (the x offset range from the main camera path)
	/// </summary>
	[Tooltip("In meters")][SerializeField] private float xRange = 5f;
    /// <summary>
	/// The range the ship can move to the vertical extents of the screen (the Y offset range from the main camera path) 
	/// </summary>
	[Tooltip("In meters")][SerializeField] private float yRange = 3.5f;

    [Header("Screeb-position based")]
    /// <summary>
	/// relates the vertical position to the pitch
	/// </summary>
	[SerializeField] float positionPitchFactor = -5f;
    /// <summary>
	/// relates the vertical position to the yaw
	/// </summary>
	[SerializeField] float positionYawFactor = 5f;
	
    [Header("Control-throw Based")]
    /// <summary>
    /// relates the vertical throw to the pitch
    /// </summary>
    [SerializeField] float controlPitchFactor = -20f;
    /// <summary>
	/// relates the horizontal throw to the roll
	/// </summary>
	[SerializeField] float controlRollFactor = -20f;

	private float xThrow, yThrow = 0f;
    private bool isControlEnabled = true;
	
	#endregion
	#region lifecycle methods

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (isControlEnabled)
	    {
	        ProcessTranslation();
	        ProcessRotation();
        }
		
	}

    // NOTE - called by string reference
    void OnPlayerDeath()
    {
        // freeze controls
        isControlEnabled = false;
    }
	#endregion
	#region Gameplay Methods

	private void ProcessTranslation()
	{
		// grab the user input values
		xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
		yThrow = CrossPlatformInputManager.GetAxis("Vertical");

		// calculate the new x vector value
		float xOffset = xThrow * xSpeed * Time.deltaTime;
		float rawXPos = transform.localPosition.x + xOffset;
		float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

		// calculate the new y vector value
		float yOffset = yThrow * ySpeed * Time.deltaTime;
		float rawYPos = transform.localPosition.y + yOffset;
		float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

		// apply the new vector to the game object
		transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
	}

	private void ProcessRotation()
	{
		// calculate pitch
		float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
		float pitchDueToControlThrow = yThrow * controlPitchFactor;
		float pitch = pitchDueToPosition + pitchDueToControlThrow;

		// calculate the yaw
		float yaw = transform.localPosition.x * positionYawFactor;

		// calculate the roll
		float roll = xThrow * controlRollFactor;

		// apply the rotation to the game object
		transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
	}
	#endregion
}

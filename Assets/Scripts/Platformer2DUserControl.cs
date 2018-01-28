using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof (PlatformerCharacter2D))]
public class Platformer2DUserControl : MonoBehaviour
{
	private PlatformerCharacter2D m_Character;
	private bool m_Jump;

	public string jumpButton = "Jump_P1";
	[SerializeField] private float horizontalInput = 1.0f;

	private void Awake()
	{
		m_Character = GetComponent<PlatformerCharacter2D>();
	}


	private void Update()
	{
		if (!m_Jump)
		{
			// Read the jump input in Update so button presses aren't missed.
			m_Jump = CrossPlatformInputManager.GetButtonDown(jumpButton);
		}
	}


	private void FixedUpdate()
	{
		// Read the inputs.
		//bool crouch = Input.GetKey(KeyCode.LeftControl);
		// Pass all parameters to the character control script.
		m_Character.Move(horizontalInput, false, m_Jump);
		m_Jump = false;
	}
}
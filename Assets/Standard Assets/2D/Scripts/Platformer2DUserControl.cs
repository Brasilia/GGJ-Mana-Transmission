using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof (PlatformerCharacter2D))]
public class Platformer2DUserControl : MonoBehaviour
{
	private PlatformerCharacter2D m_Character;
	private MagicUser magicUser;
	private bool m_Jump;


	private void Awake()
	{
		m_Character = GetComponent<PlatformerCharacter2D>();
		magicUser = GetComponent<MagicUser> ();
	}


	private void Update()
	{
		if (!m_Jump)
		{
			// Read the jump input in Update so button presses aren't missed.
			m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
		}

		// If is able to use magic and the Fire button is pressed...
		if (GetComponent<MagicUser>().isActiveAndEnabled && CrossPlatformInputManager.GetButtonDown ("Fire1")) {
			// ... fires the magic
			magicUser.Fire ();
		}


		// If is able to use magic and the transmission button is pressed...
		if (GetComponent<MagicUser>().isActiveAndEnabled && CrossPlatformInputManager.GetButtonDown ("Fire2")) {
			// ... transmits mana source to the other player
			magicUser.Transmission ();
		}
	}


	private void FixedUpdate()
	{
		// Read the inputs.
		bool crouch = Input.GetKey(KeyCode.LeftControl);
		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		// Pass all parameters to the character control script.
		m_Character.Move(h, crouch, m_Jump);
		m_Jump = false;
	}
}
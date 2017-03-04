using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float fSpeed;
	public float fJumpSpeed; 
	public float fGravity;
	public CharacterController cgController;
	private Vector3 moveDirection = Vector3.zero;

	void Update() {
		CharacterController controller = GetComponent<CharacterController>();
		if (cgController.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= fSpeed;
			if (Input.GetButton ("Jump")) {
				moveDirection.y = fJumpSpeed;
			}
		}
		moveDirection.y -= fGravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float fSpeed;
	public float fJumpSpeed; 
	public float fGravity;
	public Animator anim;
	public CharacterController cgController;
	private Vector3 moveDirection = Vector3.zero;

	void Start(){
		anim = GetComponent<Animator> ();
	}

	void Update() {
		CharacterController controller = GetComponent<CharacterController>(); 
		if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0) { //Condicion para que la animacion
			anim.SetFloat ("Speed", 1);												//cambie con el movimiento
			if (cgController.isGrounded) {
				moveDirection = new Vector3 (Input.GetAxis ("Vertical"), 0, Input.GetAxis ("Horizontal"));
				moveDirection = transform.TransformDirection (moveDirection);
				moveDirection *= fSpeed;
				anim.SetFloat ("Jumpman", 0);
			} else {
				anim.SetFloat ("Jumpman", 1);
			}
		} else if(cgController.isGrounded){
			anim.SetFloat ("Speed", 0); //Cambiar animacion de movimiento a estar parado
		}else if (moveDirection.y != 0){
				anim.SetFloat ("Jumpman", 1);
		}
		if (cgController.isGrounded && Input.GetButton ("Jump")) { //Salta solo si esta tocando el piso
			moveDirection.y = fJumpSpeed;
		}
		moveDirection.y -= fGravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float fSpeed;
    public float fJumpSpeed;
    public float fGravity;
    public Animator anim;
    public CharacterController cgController;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 cAngle;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        if (cgController.isGrounded)
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            { //Condicion para que la animacion
                anim.SetFloat("Speed", 1);
                //cambie con el movimiento
                //Crea un vector con los valores de entrada
                cAngle = (new Vector3(0,0,-Input.GetAxis("Horizontal")) + new Vector3(Input.GetAxis("Vertical"),0,0)).normalized;

                moveDirection = new Vector3(0.5f, 0, 0); //Se mueve
                cAngle = Quaternion.Euler(0, 90, 0) * cAngle;
                transform.rotation = Quaternion.LookRotation(cAngle);
            }
            else
            {
                moveDirection = new Vector3(0, 0, 0); //no se mueve
            }
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= fSpeed;
            anim.SetFloat("Jumpman", 0);
            anim.SetFloat("Speed", 0); //Cambiar animacion de movimiento a estar parado
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = fJumpSpeed;
                anim.SetFloat("Jumpman", 1);
            }
        }
        else
        {
            anim.SetFloat("Jumpman", 1);
        }
        moveDirection.y -= fGravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}

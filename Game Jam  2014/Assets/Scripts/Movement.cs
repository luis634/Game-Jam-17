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
    public int pNumber;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 cAngle;
    private string hAxis;
    private string vAxis;

    void Start()
    {
        anim = GetComponent<Animator>();
        hAxis = "Horizontal" + pNumber;
        vAxis = "Vertical" + pNumber;
		anim.SetFloat ("Speed", 0);
    }

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        if (cgController.isGrounded)
        {
            if (Input.GetAxis(hAxis) != 0 || Input.GetAxis(vAxis) != 0)
            { //Condicion para que la animacion
                //cambie con el movimiento
				anim.SetFloat("Speed", 1);
                //Crea un vector con los valores de entrada
                cAngle = (new Vector3(0,0,-Input.GetAxis(hAxis)) + new Vector3(Input.GetAxis(vAxis),0,0)).normalized;

                moveDirection = new Vector3(0.5f, 0, 0); //Se mueve
                cAngle = Quaternion.Euler(0, 90, 0) * cAngle;
                transform.rotation = Quaternion.LookRotation(cAngle);
            }
            else
            {
                moveDirection = new Vector3(0, 0, 0); //no se mueve
				anim.SetFloat("Speed", 0); 
            }
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= fSpeed;
            anim.SetFloat("Jumpman", 0);
            //Cambiar animacion de movimiento a estar parado
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

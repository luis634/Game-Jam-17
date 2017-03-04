using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float fSpeed0, fSpeed = 15f;
    public float fJumpSpeed;
    public float fGravity;
    public float powerUpTime;
    public float speedBoosted;
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
                cAngle = Quaternion.Euler(0, 90, 0) * cAngle;
                transform.rotation = Quaternion.LookRotation(cAngle);
                //cambie con el movimiento
				anim.SetFloat("Speed", 1);
                //Crea un vector con los valores de entrada
                cAngle = (new Vector3(0,0,-Input.GetAxis(hAxis)) + new Vector3(Input.GetAxis(vAxis),0,0)).normalized;
                moveDirection = new Vector3(1f * fSpeed0, 0, 0); //Se mueve
            }
            else
            {
                moveDirection = new Vector3(0, 0, 0); //no se mueve
				anim.SetFloat("Speed", 0); 
            }
            moveDirection = transform.TransformDirection(moveDirection);
            anim.SetFloat("Jumpman", 0);
            //Cambiar animacion de movimiento a estar parado
            if (Input.GetButton("Jump"))
            {
                StartCoroutine(speedIncrease());
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

    IEnumerator speedIncrease()
    {
        float tDuration = 0;
        float temp = fSpeed0;
        while (tDuration < powerUpTime)
        {
            if (tDuration >= powerUpTime - 0.1f)
            {
                fSpeed0 = temp;
                break;
            }
            fSpeed0 = speedBoosted;
            tDuration += Time.deltaTime;
            yield return null;  
        }
    }
    IEnumerator invisibility()
    {
        float tDuration = 0;
        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer> ();//Mete los renderers de los hijos en el arreglo
        while (tDuration < powerUpTime)
        {
            if (tDuration >= powerUpTime-0.1)
            {
                for (int i = 0; i < renderers.Length; i++)
                {
                    // hace visible
                    renderers[i].enabled = true;
                }
                break;
            }
            for (int i = 0; i < renderers.Length; i++)
            {
                //hace invisible
                renderers[i].enabled = false;
            }
            tDuration += Time.deltaTime;
            print(tDuration);
            yield return null;
        }
    }
}

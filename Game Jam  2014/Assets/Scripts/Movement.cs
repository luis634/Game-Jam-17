﻿using System.Collections;
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
    public bool lasTrae;
    public CharacterController cgController;
    public int pNumber;
    public bool frozen;
	public AudioSource audGalop;
	public AudioClip audCheck;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 cAngle;
    private string hAxis;
    private string vAxis;
	private string jButton;

    void Start()
    {
        moveDirection.y = transform.localPosition.y;
        anim = GetComponent<Animator>();
        hAxis = "Horizontal" + pNumber;
        vAxis = "Vertical" + pNumber;
		jButton = "Jump" + pNumber;  
		anim.SetFloat ("Speed", 0);
    }

    void Update()
    {
        Sound();
        CharacterController controller = GetComponent<CharacterController>();
        if (!frozen)
        {
            float fTemp;
            fTemp = fSpeed0;
            if (lasTrae)
                fSpeed0 = fTemp;
        }
        else
        {
            fSpeed0 = 0;
        }
        if (cgController.isGrounded)
        {
            if (Input.GetButton(jButton))
            {
                jump();
            }
            //anim.SetFloat("Jumpman", 0);
            //Cambiar animacion de movimiento a estar parado
            if (Input.GetAxis(hAxis) != 0 || Input.GetAxis(vAxis) != 0)
            { //Condicion para que la animacion           
                anim.SetFloat("Speed", 1);
                moveDirection = new Vector3(-Input.GetAxis(vAxis), 0, Input.GetAxis(hAxis));
                moveDirection *= fSpeed0;
                transform.rotation = Quaternion.LookRotation(new Vector3(-Input.GetAxis(hAxis), 0, -Input.GetAxis(vAxis)));
            }
            else
            {
                anim.SetFloat("Speed", 0);
            }
        }
        else
        {           
            moveDirection.y -= fGravity * Time.deltaTime;
            //anim.SetFloat("Jumpman", 1);
        }
        moveDirection.y -= fGravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

   public void jump()
    {
        moveDirection.y = fJumpSpeed;
        //anim.SetFloat("Jumpman", 1);
    }

    private void Sound()
    {
        if (Input.GetAxis(hAxis) != 0 || Input.GetAxis(vAxis) != 0)
        {
            if (audGalop.clip != audCheck && gameObject.tag == "Horse Player" || gameObject.tag == "Knight Player")
            {
                audGalop.clip = audCheck;
                audGalop.Play();
            }
        }
        else
        {
            if (audGalop.clip == audCheck && gameObject.tag == "Horse Player" || gameObject.tag == "Knight Player")
            {
                audGalop.clip = null;
            }
        }
    }

    public IEnumerator speedIncrease()
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
    public IEnumerator invisibility()
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

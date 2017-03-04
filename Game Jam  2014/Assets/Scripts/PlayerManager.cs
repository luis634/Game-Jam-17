using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public bool lasTrae = false;
    public float tFreeze;
    public bool frozen;
    private Movement Touch,thisMovement;

	// Use this for initialization
	void Start () {
        frozen = false;
        //gameObject.GetComponent<Movement>().frozen = frozen;

    }

    void Update()
    {
        thisMovement = gameObject.GetComponent<Movement>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Players"))
        {
            Touch = other.gameObject.GetComponent<Movement>();
            print("touched a player");
            if (lasTrae == false && Touch.lasTrae == false)
            {
                //no hace nada...aun
            }
            else if (lasTrae == false && Touch.lasTrae == true)
            {
                lasTrae = true;
                StartCoroutine(freeze());
            }
            else if (lasTrae == true)
            {
                lasTrae = false;
            }
        }
    }

    IEnumerator freeze()
    {
        frozen = true;
        gameObject.GetComponent<BoxCollider>().enabled = false; //Desactiva las colisiones
        print("Estoy congelado");
        yield return new WaitForSeconds(tFreeze);
        gameObject.GetComponent<BoxCollider>().enabled = true;
        frozen = false;
        print("Estoy descongelado");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public bool lasTrae;
    public float tFreeze;
    public bool frozen;
    public GameObject soldado, caballo;
	// Use this for initialization
	void Start () {
        frozen = false;
        //gameObject.GetComponent<Movement>().frozen = frozen;
        //cambio();
    }

    void Update()
    {
    }

    private void cambio()
    {
        if (lasTrae)
        {
            gameObject.tag = "Horse Player";
            caballo.SetActive(true);
            soldado.SetActive(false);
        }
        else
        {
            gameObject.tag = "Knight Player";
            caballo.SetActive(false);
            soldado.SetActive(true);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        print("touched a player");
        if (other.gameObject.tag == "Horse Player" && lasTrae == false)
        {
            lasTrae = true;
            cambio();
        }
        else if (other.gameObject.tag == "Knight Player" && lasTrae == true)
        {
            lasTrae = false;
            cambio();
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

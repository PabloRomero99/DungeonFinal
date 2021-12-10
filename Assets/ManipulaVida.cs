using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulaVida : MonoBehaviour
{
    barraDeVida vidaPlayer;
    public float da�o;

    // Start is called before the first frame update
    void Start()
    {
        vidaPlayer = GameObject.FindWithTag("DogPolyart").GetComponent<barraDeVida>();
    }

   
    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "DogPolyart")
        {   
            vidaPlayer.vida -= da�o;
        }
    }

   

    
}

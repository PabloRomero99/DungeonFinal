using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoRecuperacion : MonoBehaviour
{
    public GameObject objetoRecuperacion;
    public GameObject target;
    barraDeVida vidaPlayer;

    // Start is called before the first frame update
    void Start()
    {
        //objetoRecuperacion = GameObject.FindWithTag("Heart");
        target = GameObject.Find("DogPolyart");
        vidaPlayer = GameObject.FindWithTag("DogPolyart").GetComponent<barraDeVida>();
    }

    // Update is called once per frame
    void Update()
    {
        recuperacion();
    }

    void recuperacion()
    {
        if (Vector3.Distance(transform.position, target.transform.position) < 2)
        {
            objetoRecuperacion.SetActive(false);
            vidaPlayer.vida += 100 - vidaPlayer.vida;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo2 : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;

    public GameObject target;
    //public bool atacando1; "lanzar piedra" si no podemos solucionarlo no lo hacemos 
    public bool atacando2; 

    //public int hp;
    //public int dañoEspada;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("DogPolyart");

    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "armaImpacto")
        {
            if (anim != null)
            {
                anim.Play("");
            }
            hp -= dañoEspada;
        }
        if (hp <= 0)
        {
            Destroy(gameObject);
        }

    }*/

    public void Comportamiento_Enemigo()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 10)
        {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
            ani.SetBool("walk", false);

            //ani.SetBool("run", true);
            //transform.Translate(Vector3.forward * 4 * Time.deltaTime);

            ani.SetBool("attack2", false);
        }
        else
        {
            ani.SetBool("walk", false);
            //ani.SetBool("run", false);

            ani.SetBool("attack2", true);
            atacando2 = true;
            //ani.SetBool("run", true);
        }
        

    }

    public void Final_Ani()
    {
        ani.SetBool("attack2", false);
        atacando2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        Comportamiento_Enemigo();

    }
}

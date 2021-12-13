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
    public bool atacando;

    public int hp;
    public int dañoEspada;
    private bool isDead;



    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        ani = GetComponent<Animator>();
        target = GameObject.Find("DogPolyart");

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "armaImpacto" && target.GetComponent<PlayerScript>().estoyAtacando)
        {
            Debug.Log("DAÑO");
            hp -= dañoEspada;
        }
        if (hp <= 0)
        {
            Debug.Log("Muerto");
            isDead = true;

        }
    }

    public void Comportamiento_Enemigo()
    {

        if (Vector3.Distance(transform.position, target.transform.position) > 20)
        {
            transform.Translate(Vector3.forward * 1 * Time.deltaTime); //ani.SetBool("run", false);
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }
            switch (rutina)
            {
                case 0:
                    ani.SetBool("walk", false);
                    break;
                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    ani.SetBool("walk", true);
                    break;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, target.transform.position) > 5)
            {
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);

                ani.SetBool("walk", true);
                transform.Translate(Vector3.forward * 4 * Time.deltaTime);//ani.SetBool("run", true);


                ani.SetBool("attack", false);
            }
            else
            {
                ani.SetBool("walk", false);

                ani.SetBool("attack", true);
                atacando = true;
                ani.SetBool("walk", true);
            }
        }

    }

    public void Final_Ani()
    {
        ani.SetBool("attack", false);
        atacando = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            Comportamiento_Enemigo();
        }
    }
}

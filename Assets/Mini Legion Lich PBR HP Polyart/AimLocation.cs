using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLocation : MonoBehaviour
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

    [SerializeField] GameObject key;

    [SerializeField] GameObject bullet;
    private int counter;
    [SerializeField] private int maxCounter = 20;
    [SerializeField] private float timer = 2f;




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
            atacando = false;
            ani.SetBool("isDead", true);
            ani.SetBool("run", false);
            ani.SetBool("walk", false);
            ani.SetBool("attack", false);
        }


    }

    public void Comportamiento_Enemigo()
    {

        if (Vector3.Distance(transform.position, target.transform.position) > 50)
        {
            ani.SetBool("run", false);
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
            if (Vector3.Distance(transform.position, target.transform.position) > 20)
            {
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
                ani.SetBool("walk", false);

                ani.SetBool("run", true);
                transform.Translate(Vector3.forward * 4 * Time.deltaTime);

                ani.SetBool("attack", false);
            }
            else
            {
                ani.SetBool("walk", false);
                ani.SetBool("run", false);

                ani.SetBool("attack", true);
                atacando = true;
                //StartCoroutine(FireBullets());
                ani.SetBool("run", true);
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
            key.SetActive(false);
        }
        else
        {
            key.SetActive(true);
        }

    }
}
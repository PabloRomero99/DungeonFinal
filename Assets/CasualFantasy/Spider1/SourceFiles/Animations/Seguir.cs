using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguir : MonoBehaviour
{
    public Animator ani;
    public GameObject target;



    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        ani.SetBool("walk", true);
        target = GameObject.Find("DogPolyart");

    }

    public void Comportamiento_Enemigo()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 20)
        {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);

            ani.SetBool("walk", true);
            transform.Translate(Vector3.forward * 4 * Time.deltaTime);//ani.SetBool("run", true);

        }
        else
        {
            transform.Translate(Vector3.forward * 1 * Time.deltaTime);
            ani.SetBool("walk", true);
        }
    }    
}

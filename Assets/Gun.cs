using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public GameObject target;
    public int contador;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("FreeLichPolyart");
        contador = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        if (target.GetComponent<AimLocation>().atacando)
        {
           
            if(contador == 60)
            {
                contador = 0;
                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            }
            contador++;
         
        }

    }

   
}

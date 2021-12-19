using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float timelife = 5f;
    public GameObject target;

    //public GameObject explosionEffect;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("DogPolyart");
        Destroy(gameObject, timelife);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

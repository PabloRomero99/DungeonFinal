using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public gameObject bullet;
    [SerializeField]
    private float timer = 2f;
    //private float timerCount = 0f;

    
    private int counter;
    [SerializeField]
    private int maxCounter = 20;

    void Start()
    {
        StartCoroutine(FireBullet_CR());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FireBullets_CR()
    {
        for(int i = 0; i < maxCounter; i++)
        {
            counter++;
            Instantiate(bullet, transform.position, transform.rotation);
            yield return new WaitForSeconds(timer);
        }
    }
}

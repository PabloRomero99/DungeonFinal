using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{

    public Animator playerAnimator;
    public bool estoyAtacando;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && !estoyAtacando)
        {
            estoyAtacando = true;
            playerAnimator.SetTrigger("Attack1");
            estoyAtacando = false;
        }
    }

    void FixedUpdate()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controlador;
    public float speed = 5f;
    public Animator playerAnimator;
    public bool isRunning;
    public float jump = 10f;
    float speedVertical; 


    // Start is called before the first frame update
    void Start()
    {
        controlador = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        if (controlador.isGrounded)
        {
            speedVertical = -1 * Time.deltaTime;
            if (Input.GetButtonDown("Jump"))
            {
                speedVertical = jump * Time.deltaTime;           
            }
        }
        else
        {
            speedVertical -= 1 * Time.deltaTime;
        }
        Vector3 movimientoDelta = new Vector3(x,speedVertical,z);
        controlador.Move(movimientoDelta);

        if (Input.GetAxis("Horizontal") > 0)
        {
            playerAnimator.SetBool("IsRunning",true);
            isRunning = true;
            transform.eulerAngles = new Vector3(0,90,0); 
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            playerAnimator.SetBool("IsRunning", true);
            isRunning = true;
            transform.eulerAngles = new Vector3(0, -90, 0);
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            playerAnimator.SetBool("IsRunning", true);
            isRunning = true;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            playerAnimator.SetBool("IsRunning", true);
            isRunning = true;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

      

        if (Input.GetAxis("Vertical")==0 && Input.GetAxis("Horizontal")==0)
        {
            playerAnimator.SetBool("IsRunning", false);
            isRunning = false;
        }

        
    }
}

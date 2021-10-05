using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed;

    Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.SceenToWorldPoint(Input.mousePosition);

            target.z = 0f;
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deletaTime);

        Debug.DrawLine(transform.position, target, Color.green);
    }
}

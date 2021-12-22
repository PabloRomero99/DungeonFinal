using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainMove : MonoBehaviour
{
    [SerializeField] GameObject key1;
    [SerializeField] GameObject key2;
    [SerializeField] GameObject key3;
    [SerializeField] GameObject key4;
    [SerializeField] GameObject mountain;
    
    // Update is called once per frame
    void Update()
    {
        if (key1.activeSelf && key2.activeSelf && key3.activeSelf && key4.activeSelf)
        {
            mountain.SetActive(false);
        }
    }
}

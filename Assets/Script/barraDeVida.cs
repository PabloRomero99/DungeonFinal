using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barradevida : MonoBehaviour
{
    public float vida = 100;

    public Image barraVida;

    // Update is called once per frame
    void Update()
    {
        vida = Mathf.Clamp(vida, 0, 100);

        barraVida.fillAmount = vida / 100;
    }
}

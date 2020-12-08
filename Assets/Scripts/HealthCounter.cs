using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthCounter : MonoBehaviour
{
    public GameObject player;
    PlayerHealth hc;
    Text txt;
    // Start is called before the first frame update
    void Start()
    {
        hc = player.GetComponent<PlayerHealth>();
        txt = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = Math.Ceiling(hc.getHealth()).ToString();
    }
}

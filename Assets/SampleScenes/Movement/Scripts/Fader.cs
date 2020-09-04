using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Fader : MonoBehaviour
{
    public Rigidbody player;
    private UnityEngine.UI.Image panel;

    // Start is called before the first frame update
    void Start()
    {
       panel = GetComponent<UnityEngine.UI.Image>();      
    }

    // Update is called once per frame
    void Update()
    {
        var p = player.transform.position - panel.transform.position;

        double hyp = Math.Sqrt((p.x * p.x) + (p.z * p.z));


        panel.color = new Color(255, 255, 0, (float)(1 / hyp));
    }
}

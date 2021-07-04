using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using REAL = System.Double;

public class CycloneRunner : MonoBehaviour
{
    public Particle particleObje; 
    void Start()
    {

        // Assign particle script of the object Particle object
        particleObje = GetComponent<Particle>();
        // Assign initial game object position to Particle object
        particleObje.position = Vector3d.getPosition(transform.position);
        particleObje.velocity = new Vector3d(0, 0, 0);
        particleObje.acceleration = new Vector3d(0, 0, 0);
        particleObje.forceAccum = new Vector3d(0, 0, 0);
        particleObje.damping = 0.99;


    }

    // Update is called once per frame  
    void Update()
    {

        //integrate object over time - 0.04tü eskisi
        particleObje = Particle.integrate(Time.deltaTime, particleObje);

        //apply new position to gameObject
        transform.position = Vector3d.updatePosition(particleObje.position);


    }
}

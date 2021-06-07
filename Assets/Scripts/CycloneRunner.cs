using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using REAL = System.Double;

public class CycloneRunner : MonoBehaviour
{
    public Particle particleObje = new Particle();
    // Start is called before the first frame update
    void Start()
    {
        // Assign particle script of the object Particle object
        particleObje=GetComponent<Particle>();
        // Assign initial game object position to Particle object
        particleObje.position = Vector3d.getPosition(transform.position);

        //di�er de�i�kenleri de ba�tan tan�mlamak gerekiyor sonras�nda bunlar hep 0 olarak ba�layacaklar
        particleObje.velocity = new Vector3d(10, 20, 30); 
        particleObje.acceleration = new Vector3d(0, 0, 0); 


    }

    // Update is called once per frame
    void Update()
    {
        //integrate object over time
        particleObje = Particle.integrate(0.01, particleObje);
        //apply new position to gameObject
        transform.position = Vector3d.updatePosition(particleObje.position); 


    }
}

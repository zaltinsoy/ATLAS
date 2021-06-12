using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using REAL = System.Double;

public class CycloneRunner : MonoBehaviour
{
    public Particle particleObje; //burada new'le baþlamak bir hataya sebep oluyor gibi, garip bir durum gerçekten de, þimdilik vazgeçelim.
    //public Particle particleObje = new Particle();
    // Start is called before the first frame update
    void Start()
    {

        // Assign particle script of the object Particle object
        particleObje = GetComponent<Particle>();
        // Assign initial game object position to Particle object
        particleObje.position = Vector3d.getPosition(transform.position);

        //diðer deðiþkenleri de baþtan tanýmlamak gerekiyor sonrasýnda bunlar hep 0 olarak baþlayacaklar
        particleObje.velocity = new Vector3d(0, 0, 0);
        particleObje.acceleration = new Vector3d(0, 0, 0);
        particleObje.forceAccum = new Vector3d(0, 0, 0); //bunlar tam sayý olunca çok etkili oluyorlar.
        particleObje.damping = 0.99;


    }

    // Update is called once per frame  
    void Update()
    {
        //integrate object over time - 0.04tü eskisi
        particleObje = Particle.integrate(Time.deltaTime, particleObje);

        //apply new position to gameObject
        transform.position = Vector3d.updatePosition(particleObje.position);

        //buradan aþaðýsý kuvvet uygulama kýsmý oldu hepten
        //anlýk kuvvet aþaðýdaki þekilde uygulanýyor:
        // particleObje= Particle.AddForce(new Vector3d(0, 0.1, 0), particleObje);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //apply force to object
            particleObje.acceleration = new Vector3d(0, 1, 0);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            particleObje.acceleration = new Vector3d(0, -1, 0);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            particleObje.acceleration = new Vector3d(0, 0, 0);
            particleObje.velocity = new Vector3d(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            particleObje.acceleration = new Vector3d(1, 0, 0);
            particleObje.velocity = new Vector3d(0, 0, 0);
        }

      //  Debug.Log(particleObje.acceleration.y);


    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using REAL = System.Double;


public class Particle : MonoBehaviour
{

    public Vector3d position = new Vector3d(); //private olunca sýkýntýya giriyoruz
        public Vector3d velocity = new Vector3d();
        public Vector3d forceAccum = new Vector3d();
        public Vector3d acceleration = new Vector3d();
        public REAL inverseMass = new REAL();
        public REAL damping = new REAL();
        public REAL mass = new REAL();
    public GameObject particleObject = new GameObject();

    private void Start()
    {
        //atama yapacaksam eðer tüm atamalarý burada yapmak lazým!
       // particleObject = gameObject; //particle'ýn içine kendi gameObject'ini atadýk, sonunda

     //   ball = Particle.integrate(0.01, ball); // bu do
      //  transform.position = Vector3d.updatePosition(position); //apply to gameObject
       // position = Vector3d.getPosition(transform.position); //
        
    }
    private void Update()
    {

    }
 
    public static Particle integrate(REAL duration, Particle obje)
        {
            Vector3d resultingAcc = new Vector3d();
            //update linear positionc
            obje.position = Vector3d.addScaledVector(obje.position, obje.velocity, duration);

            //obje.acceleration;
            resultingAcc = obje.acceleration;

            //Update linear velocity from the acceleration;
            obje.velocity = Vector3d.addScaledVector(obje.velocity, resultingAcc, duration);

            //Impose drag
            obje.velocity.x *= Math.Pow(obje.damping, duration);
            obje.velocity.y *= Math.Pow(obje.damping, duration);
            obje.velocity.z *= Math.Pow(obje.damping, duration);

        return obje;
        }
    


}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using REAL = System.Double;


public class Particle : MonoBehaviour
{

    public Vector3d position;
    public Vector3d velocity;
    public Vector3d forceAccum;
    public Vector3d acceleration;
    public REAL inverseMass;
    public REAL damping ;
    public REAL mass ;
    public GameObject particleObject;
    public REAL radius;

    private void Start()
    {
      radius = transform.localScale.x; //�al���yor buras�, ba�ta tan�mland��� i�in s�k�nt�l� sonras�nda de�i�miyor bu
           Vector3d position = new Vector3d(); //private olunca s�k�nt�ya giriyoruz
    Vector3d velocity = new Vector3d();
    Vector3d forceAccum = new Vector3d();
    Vector3d acceleration = new Vector3d();
    REAL inverseMass = new REAL();
    REAL damping = new REAL();
    GameObject particleObject = new GameObject();

        //atama yapacaksam e�er t�m atamalar� burada yapmak laz�m!
        // particleObject = gameObject; //particle'�n i�ine kendi gameObject'ini atad�k, sonunda

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
        //resultingAcc'ye niye ihtiya� var onu ��karamad�m burada hi�.
        resultingAcc = obje.acceleration;
        resultingAcc = Vector3d.addScaledVector(resultingAcc, obje.forceAccum, obje.inverseMass);
        obje.acceleration = resultingAcc;

        //Update linear velocity from the acceleration;
        obje.velocity = Vector3d.addScaledVector(obje.velocity, resultingAcc, duration);

        //Impose drag
        obje.velocity.x *= Math.Pow(obje.damping, duration);
        obje.velocity.y *= Math.Pow(obje.damping, duration);
        obje.velocity.z *= Math.Pow(obje.damping, duration);

        //clear the force accumulator and acceleration
        //acceleration'� temizlemeyince sonras�nda �i�tik�e �i�iyor tabi
        //sonraki a�amaya sadece position ve velocity aktar�l�yor, acceleration bunlarla oynamak i�in dolayl� olarak i� g�r�yor.
        obje.forceAccum = new Vector3d(0, 0, 0);
        obje.acceleration = new Vector3d(0, 0, 0); 

        return obje;
    }

    //to add force to the object
    public static Particle AddForce(Vector3d force,Particle obje)
    {
        obje.forceAccum += force;
        return obje;
    }



}

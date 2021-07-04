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
    public REAL damping;
    public REAL mass;
    public GameObject particleObject;

    private void Start()
    {
        Vector3d position = new Vector3d();
        velocity = new Vector3d();
        forceAccum = new Vector3d();
        acceleration = new Vector3d();
        inverseMass = new REAL();
        damping = new REAL();
        GameObject particleObject = new GameObject();
        damping = 0.95;

        if (mass == 0) { inverseMass = mass; }
        else { inverseMass = 1 / mass; }

    }
    private void Update()
    {

    }

    public static Particle integrate(REAL duration, Particle obje)
    {
        Vector3d resultingAcc = new Vector3d();

        //update linear positionc
        obje.position = Vector3d.addScaledVector(obje.position, obje.velocity, duration);
        
        
        resultingAcc = obje.acceleration;
        resultingAcc = Vector3d.addScaledVector(resultingAcc, obje.forceAccum, obje.inverseMass);
        obje.acceleration = resultingAcc;

        //Update linear velocity from the acceleration;
        obje.velocity = Vector3d.addScaledVector(obje.velocity, resultingAcc, duration);
        
        //Impose drag
        obje.velocity.x *= Math.Pow(obje.damping, duration);
        obje.velocity.y *= Math.Pow(obje.damping, duration);
        obje.velocity.z *= Math.Pow(obje.damping, duration);

        obje.forceAccum = new Vector3d(0, 0, 0);
        obje.acceleration = new Vector3d(0, 0, 0);

        return obje;
    }

    //to add force to the object
    public static Particle AddForce(Vector3d force, Particle obje)
    {
        obje.forceAccum += force;
        return obje;
    }
    public static Particle StopForce(Vector3d velo, Particle obje)
    {
        obje.velocity -= velo;
        return obje;
    }

    public static Particle AddVelocity(Vector3d velo, Particle obje)
    {
        obje.velocity += velo;
        return obje;
    }
    public static Particle MovePlayer(Vector3d move, Particle obje)
    {
        obje.position += move;
        return obje;
    }

    public static Particle SteadyPlayer(Vector3d move, Particle obje)
    {
        obje.position += move;
        return obje;
    }


}

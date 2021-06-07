using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using REAL = System.Double;

public class Vector3d : MonoBehaviour
{
    
    public REAL x = new REAL();
    public REAL y = new REAL();
    public REAL z = new REAL();
    
    public Vector3d (REAL x1,REAL y1,REAL z1)
    {
        x = x1;
        y = y1;
        z = z1;
    }

    public Vector3d ()
    { 

    }

    //Calculates magnitude of a vector
    public static REAL magnitude(Vector3d v)
    {
        return Math.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z);
    }
    //Calculates square magnitude of a vector

    public static REAL SquareMagnitude(Vector3 v)
    {
        return v.x * v.x + v.y * v.y + v.z * v.z;
    }

    //Transform a vector to its inverse
    public static Vector3d invert(Vector3d v)
    {
        v.x = -v.x;
        v.y = -v.y;
        v.z = -v.z;
        return v;
    }
    //
    public static Vector3d addScaledVector(Vector3d v, Vector3d u, REAL s)
    {
        Vector3d vec = new Vector3d();
        vec.x = v.x + s * u.x;
        vec.y = v.y + s * u.y;
        vec.z = v.z + s * u.z;
        return vec;
    }

    public static REAL scalarProduct(Vector3d v, Vector3d u)
    {
        return v.x * u.x + v.y * u.y + v.z * u.z;
    }

    public static Vector3d vectorProduct(Vector3d v, Vector3d u)
    {
        Vector3d vec = new Vector3d();
        vec.x = v.y * u.z - v.z * u.y;
        vec.y = v.z * u.x - v.x * u.z;
        vec.z = v.x * u.z - v.y * u.x;

        return vec;
    }

    public static Vector3d operator *(REAL s, Vector3d v)
    {
        Vector3d vec = new Vector3d();

        vec.x = v.x * s;
        vec.y = v.y * s;
        vec.z = v.z * s;
        return vec;
    }
    public static Vector3d operator +(Vector3d v, Vector3d u)
    {
        Vector3d vec = new Vector3d();
        vec.x = v.x + u.x;
        vec.y = v.y + u.y;
        vec.z = v.z + u.z;

        return vec;
    }


    public static Vector3d operator -(Vector3d v, Vector3d u)
    {
        Vector3d vec = new Vector3d();
        vec.x = v.x - u.x;
        vec.y = v.y - u.y;
        vec.z = v.z - u.z;
        return vec;
    }

    //transform Cyclone Vector class to the Unity Vector class
    public static Vector3 updatePosition(Vector3d v)
    {
        Vector3 vec = new Vector3();
        vec.x = (float)v.x;
        vec.y = (float)v.y;
        vec.z = (float)v.z;
        return vec;
    }

    public static Vector3d getPosition(Vector3 pos)
    {
        Vector3d newCoor = new Vector3d();
        newCoor.x = pos.x;
        newCoor.y = pos.y;
        newCoor.z = pos.z;
        return newCoor;
    }
    /*
    public static Vector3d getCoordinate()

    {
        Vector3d vec = new Vector3d();
        float a = transform.position.x;
        transform.position.x
        //float a =Transform.
        positi
        return v;
    }
    */

}

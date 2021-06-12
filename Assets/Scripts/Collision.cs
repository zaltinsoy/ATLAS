using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


public class Collision : MonoBehaviour
{
    public GameObject[] gravy;
    public GameObject[] lazy;
    public GameObject[] rigidObjects;
    private double numMoving;
    private double numStable;
    private double difference;
    private double restitution;

    Particle parGravy = new Particle();
    Particle parGravy2 = new Particle();
    Particle parGravy3 = new Particle();
    Particle parGravy4 = new Particle();
    double xDif;
    double yDif;
    double zDif;
    double xLim;
    double yLim;
    double zLim;
    double xPenet;
    double yPenet;
    double zPenet;
    double minPen;

    // Start is called before the first frame update
    void Start()
    {
        //get the list of all moving and not moving objects.
        gravy = GameObject.FindGameObjectsWithTag("gravy");
        lazy = GameObject.FindGameObjectsWithTag("lazy");
        //gravy = Object.FindObjectOfType<Particle>().gameObject;

        gravy = gravy.Concat(lazy).ToArray();
        //gravy.Add(lazy);
        //rigidObjects = gravy + lazy;


        numMoving = gravy.Length;
        numStable = lazy.Length;
        restitution = 1;

        //Not working:
        //getall[0] = Object.FindObjectOfType<Particle>(); 
        // particleList.AddRange((IEnumerable<Particle>)FindObjectOfType<Particle>()); 
    }

    void Update()
    {
        for (int i = 0; i < numMoving; i++)
        {
            for (int j = 0; j < numMoving; j++)
            {
                if (i == j)
                {
                    continue;
                }
                parGravy = gravy[i].GetComponent<Particle>();
                parGravy2 = gravy[j].GetComponent<Particle>();
                difference = Vector3d.disBetween(parGravy.position, parGravy2.position);
                xDif = Math.Abs(parGravy.position.x - parGravy2.position.x);
                yDif = Math.Abs(parGravy.position.y - parGravy2.position.y);
                zDif = Math.Abs(parGravy.position.z - parGravy2.position.z);

                xLim = parGravy.transform.localScale.x / 2 + parGravy2.transform.localScale.x / 2;
                yLim = parGravy.transform.localScale.y / 2 + parGravy2.transform.localScale.y / 2;
                zLim = parGravy.transform.localScale.z / 2 + parGravy2.transform.localScale.z / 2;

                xPenet = xLim - xDif;
                yPenet = yLim - yDif;
                zPenet = zLim - zDif;
                minPen = Math.Min(xPenet, Math.Min(yPenet, zPenet));

                //if (difference < parGravy.radius)
                //Aþaðýdaki içiçelik yöntemi çalýþtý gibi þu an
                if (difference < parGravy.radius && xDif < xLim && yDif < yLim && zDif < zLim)
                {

                    //get contact normal
                    Vector3d conNormal = Vector3d.normalize(parGravy.position - parGravy2.position);
                    //get relative velocity of the objects

                    if (parGravy.inverseMass == 0||parGravy2.inverseMass == 0)
                    {
                        if (minPen== xPenet)
                        {
                            conNormal = new Vector3d(1, 0, 0);
                        }
                        if (minPen == yPenet)
                        {
                            conNormal = new Vector3d(0, 1, 0);
                        }
                        if (minPen == zPenet)
                        {
                            conNormal = new Vector3d(0, 0, 1);
                        }

                    }

                    Vector3d relVelocity = parGravy.velocity - parGravy2.velocity;
                    //get seperation and define restituion
                    double sepVelocity = Vector3d.scalarProduct(relVelocity, conNormal);

                    if (sepVelocity < 0)
                    {
                        double totalInverseMass = parGravy.inverseMass + parGravy2.inverseMass;


                        double newSepVelocity = -restitution * sepVelocity;
                        double deltaVelocity = newSepVelocity - sepVelocity;

                        /*
                        if (parGravy.inverseMass == 0||parGravy2.inverseMass==0);
                        {
                            continue;
                        }
                        */

                        //double penetration = parGravy.radius - difference;
                        //double penetration = Math.Max(xPenet, Math.Max(yPenet, zPenet));
                        double penetration = minPen;
                        Vector3d movePerIMass = (penetration / totalInverseMass) * conNormal;

                        parGravy.position += parGravy.inverseMass * movePerIMass;
                        parGravy2.position -= parGravy2.inverseMass * movePerIMass;


                        double impulse = deltaVelocity / totalInverseMass;
                        Vector3d impulsePerIMass = impulse * conNormal;

                        parGravy.velocity += parGravy.inverseMass * impulsePerIMass;
                        parGravy2.velocity -= parGravy.inverseMass * impulsePerIMass;
                    }


                }

            }
        }

        /*
        for (int i = 0; i < numMoving; i++)
        {
            for (int j = 0; j < numStable; j++)
            {
                Debug.Log("i" + i);
                Debug.Log("j" + j);
                parGravy3 = gravy[i].GetComponent<Particle>();
                parGravy4 = lazy[j].GetComponent<Particle>();
                difference = Vector3d.disBetween(parGravy3.position, parGravy4.position);
               // Debug.Log("i"+i);
                //Debug.Log("j"+j);
                if (difference < parGravy3.radius)
                {
                    //get contact normal
                    Vector3d conNormal = Vector3d.normalize(parGravy3.position - parGravy4.position);
                    //get relative velocity of the objects
                    Vector3d relVelocity = parGravy3.velocity - parGravy4.velocity;
                    //get seperation and define restituion
                    double sepVelocity = Vector3d.scalarProduct(relVelocity, conNormal);

                    double newSepVelocity = -restitution * sepVelocity;
                    double deltaVelocity = newSepVelocity - sepVelocity;

                    double totalInverseMass = parGravy3.inverseMass + parGravy4.inverseMass;
                    double impulse = deltaVelocity / totalInverseMass;
                    Vector3d impulsePerIMass = impulse * conNormal;

                    parGravy3.velocity += parGravy3.inverseMass * impulsePerIMass;
                    parGravy4.velocity -= parGravy4.inverseMass * impulsePerIMass;


                }

            }
        }
        */





    }


}


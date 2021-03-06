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

    Particle parGravy ;
    Particle parGravy2 ;
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

        parGravy=new Particle();
        parGravy2 = new Particle();
        
        //get the list of all moving and not moving objects.
        gravy = GameObject.FindGameObjectsWithTag("gravy");
        lazy = GameObject.FindGameObjectsWithTag("lazy");
        gravy = gravy.Concat(lazy).ToArray(); 
        

        numMoving = gravy.Length;
        numStable = lazy.Length;
        restitution = 0; //0 together, 1 bounce

    }

    void Update()
    {
        for (int i = 0; i < numMoving; i++) 
        {
            for (int j = 0; j < numMoving; j++) 
            {
                if (i == j){continue;}

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


                if (xDif < xLim && yDif < yLim && zDif < zLim)
                {
                    if (parGravy.inverseMass == 0 && parGravy2.inverseMass == 0) { continue; }
                    //get contact normal
                    Vector3d conNormal = Vector3d.normalize(parGravy.position - parGravy2.position);
                    //get relative velocity of the objects


                        if (minPen == xPenet)
                        {
                           
                            if (parGravy.velocity.x < 0) { conNormal = new Vector3d(1, 0, 0); }
                            else if (parGravy.velocity.x > 0) { conNormal = new Vector3d(-1, 0, 0); }
                            else if (parGravy.velocity.x == 0) { conNormal = new Vector3d(0, 0, 0); }

                        }
                        if (minPen == yPenet)
                        {
                            if (parGravy.velocity.y < 0) { conNormal = new Vector3d(0, 1, 0); }
                            else if (parGravy.velocity.y > 0) { conNormal = new Vector3d(0, -1, 0); }
                            else if (parGravy.velocity.y == 0) { conNormal = new Vector3d(0, 0, 0); }
                        }

                        if (minPen == zPenet)
                        {
                          
                            if (parGravy.velocity.z < 0) { conNormal = new Vector3d(0, 0, 1); }
                            else if (parGravy.velocity.z > 0) { conNormal = new Vector3d(0, 0, -1); }
                            else if (parGravy.velocity.z == 0) { conNormal = new Vector3d(0, 0, 0); }
                        }

                    
                    Vector3d relVelocity = parGravy.velocity - parGravy2.velocity;
                    //get seperation and define restituion
                    double sepVelocity = Vector3d.scalarProduct(relVelocity, conNormal);

                    if (sepVelocity < 0)
                    {
                        double totalInverseMass = parGravy.inverseMass + parGravy2.inverseMass;


                        double newSepVelocity = -restitution * sepVelocity;
                        double deltaVelocity = newSepVelocity - sepVelocity;

                        
                        double penetration = minPen;
                        Vector3d movePerIMass = (penetration / totalInverseMass) * conNormal;

                        parGravy.position += parGravy.inverseMass * movePerIMass;
                        parGravy2.position -= parGravy2.inverseMass * movePerIMass;


                        double impulse = deltaVelocity / totalInverseMass;
                        Vector3d impulsePerIMass = impulse * conNormal;

                        parGravy.velocity += parGravy.inverseMass * impulsePerIMass;
                        parGravy2.velocity -= parGravy2.inverseMass * impulsePerIMass;

                    }


                }

            }
        }

        


    }


}


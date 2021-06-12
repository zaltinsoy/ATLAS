using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public Particle ball = new Particle();
    public GameObject[] gravy;
    public GameObject[] lazy;
    private double numMoving;
    private double difference;
    private double restitution;


    Particle parGravy = new Particle();
    Particle parGravy2 = new Particle();

    // Start is called before the first frame update
    void Start()
    {
        //get the list of all moving and not moving objects.
        gravy = GameObject.FindGameObjectsWithTag("gravy");
        lazy = GameObject.FindGameObjectsWithTag("lazy");
        numMoving = gravy.Length;
        restitution = 0;

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

                if (difference < parGravy.radius)
                {
                    //get contact normal
                    Vector3d conNormal = Vector3d.normalize(parGravy.position - parGravy2.position);
                    //get relative velocity of the objects
                    Vector3d relVelocity = parGravy.velocity - parGravy2.velocity;
                    //get seperation and define restituion
                    double sepVelocity = Vector3d.scalarProduct(relVelocity, conNormal);

                    double newSepVelocity = -restitution * sepVelocity;
                    double deltaVelocity = newSepVelocity - sepVelocity;

                    double totalInverseMass = parGravy.inverseMass + parGravy2.inverseMass;
                    double impulse = deltaVelocity / totalInverseMass;
                    Vector3d impulsePerIMass = impulse * conNormal;

                    parGravy.velocity += parGravy.inverseMass * impulsePerIMass;
                    parGravy2.velocity -= parGravy.inverseMass * impulsePerIMass;


                }

            }
        }





    }


}


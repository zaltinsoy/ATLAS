using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using REAL = System.Double;

public class CycloneRunner : MonoBehaviour
{
    public Particle particleObje; //burada new'le ba�lamak bir hataya sebep oluyor gibi, garip bir durum ger�ekten de, �imdilik vazge�elim.
    //public Particle particleObje = new Particle();
    // Start is called before the first frame update
    void Start()
    {

        // Assign particle script of the object Particle object
        particleObje=GetComponent<Particle>();
        // Assign initial game object position to Particle object
        particleObje.position = Vector3d.getPosition(transform.position);

        //di�er de�i�kenleri de ba�tan tan�mlamak gerekiyor sonras�nda bunlar hep 0 olarak ba�layacaklar
        particleObje.velocity = new Vector3d(0, 0, 0); 
        particleObje.acceleration = new Vector3d(0, 0, 0);
        particleObje.forceAccum = new Vector3d(0, 0, 0); //bunlar tam say� olunca �ok etkili oluyorlar.

       
    }

    // Update is called once per frame  
    void Update()
    {
        //integrate object over time
        particleObje = Particle.integrate(0.01, particleObje);
        //apply new position to gameObject
        transform.position = Vector3d.updatePosition(particleObje.position);

        if (Input.GetKeyDown(KeyCode.Space) )
        {
            //apply force to object
            //force uyguluyor ama kal�c� oluyor bu (do�ru mu?)
           // particleObje= Particle.AddForce(new Vector3d(0, 0.1, 0), particleObje);
            particleObje.acceleration = new Vector3d(0, 1, 0);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            //apply force to object
            //force uyguluyor ama kal�c� oluyor bu (do�ru mu?)
            //particleObje = Particle.AddForce(new Vector3d(0, -0.1, 0), particleObje);
            particleObje.acceleration = new Vector3d(0, -1, 0);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            //apply force to object
            //force uyguluyor ama kal�c� oluyor bu (do�ru mu?)
            //particleObje = Particle.AddForce(new Vector3d(0, -0.1, 0), particleObje);
            particleObje.acceleration = new Vector3d(0, 0, 0);
            particleObje.velocity = new Vector3d(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            //apply force to object
            //force uyguluyor ama kal�c� oluyor bu (do�ru mu?)
            //particleObje = Particle.AddForce(new Vector3d(0, -0.1, 0), particleObje);
            particleObje.acceleration = new Vector3d(1, 0, 0);
            particleObje.velocity = new Vector3d(0, 0, 0);
        }




        //Debug.Log(particleObje.forceAccum.y);
        Debug.Log(particleObje.acceleration.y);


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
<<<<<<< HEAD


=======
    public Particle ball = new Particle();
    public GameObject[] gravy;
    public GameObject[] lazy;
>>>>>>> parent of b31c963 (Collision detection & solver)
    //Define the particle, particle diye yeni þey tanýmlamýþtýk.

    //private List getAll = new List<Particle>();
    //public List<Particle> particleList;
    //List<Particle> creatureZones = new List<Particle>();

    //public List<Particle> getall;
    // private Particle[] getall =new Particle[2];

    //public List<GameObject> Floor = new List<GameObject>();
    // public List<Particle> particleList = new List<Particle>();

    // var expectedCanvasObjects = new Particle[2];

    void Start()
    {
        //Set Cursor to not be visible
        Cursor.visible = false;
    }

    private void Update()
    {
<<<<<<< HEAD



                /*
              //  Debug.Log("game settng update giriþ");
          getall.position = Vector3d.getPosition(getall.particleObject.transform.position);
        getall[0].position = Vector3d.getPosition(getall[0].particleObject.transform.position);

        */


    }
=======
        //objelerin yakýnlaþmasýný bu þekilde ölçebiliyorum artýk en azýndan circular þeyler için
        Particle parGravy = gravy[0].GetComponent<Particle>();
        Particle parGravy2 = gravy[1].GetComponent<Particle>();
        double fark=Vector3d.disBetween(parGravy.position, parGravy2.position);

        Vector3d conNormal = Vector3d.normalize(parGravy.position - parGravy2.position);
        Vector3d relVelocity = parGravy.velocity - parGravy2.velocity;
        double closingVelocity = Vector3d.scalarProduct(relVelocity, conNormal);
        
        Debug.Log("conx" + conNormal.x);
        Debug.Log("cony" + conNormal.y);
        Debug.Log("conz" + conNormal.z);

        Debug.Log("closing"+closingVelocity);
       //Debug.Log("Y" + closingVelocity.y);
        //Debug.Log("Z" + closingVelocity.z);

        if (fark < parGravy.radius)
        {
            Debug.Log("booom");
            
        }

         
        // double k=gravy.Length;
        // parGravy.position

        // gravy[0].

        //  for (int i = 0; i < k; i++)
        // {
        //      Console.WriteLine(i);
        //  }


    }
    /*
          //  Debug.Log("game settng update giriþ");
      getall.position = Vector3d.getPosition(getall.particleObject.transform.position);
    getall[0].position = Vector3d.getPosition(getall[0].particleObject.transform.position);

    */




    // Debug.Log("pos update");
    //ball.velocity.x = 5;
    //ball = Particle.integrate(0.01, ball);



>>>>>>> parent of b31c963 (Collision detection & solver)
}

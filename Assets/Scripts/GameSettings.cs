using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public Particle ball = new Particle();
    public GameObject[] gravy;
    public GameObject[] lazy;
    //Define the particle, particle diye yeni �ey tan�mlam��t�k.

    //private List getAll = new List<Particle>();
    //public List<Particle> particleList;
    //List<Particle> creatureZones = new List<Particle>();

    //public List<Particle> getall;
    // private Particle[] getall =new Particle[2];

    //public List<GameObject> Floor = new List<GameObject>();
    // public List<Particle> particleList = new List<Particle>();

    // var expectedCanvasObjects = new Particle[2];

    // Start is called before the first frame update
    void Start()
    {
        //Set Cursor to not be visible
        Cursor.visible = false;

        //respawns = GameObject.FindGameObjectsWithTag("Respawn");
        gravy = GameObject.FindGameObjectsWithTag("gravy");
        lazy = GameObject.FindGameObjectsWithTag("lazy");
        Debug.Log("asdasd;");
        //�al��m�yor a�a��dakiler
        //Ama� particle olan t�m game objeleri toplamakt� ama bir t�rl� d�zg�n �ekilde ��zemedim bu i�i, sonra devam edilecek
        //Bu y�zden tek tek ��zmek olacak sonraki ad�m�m
        //getall[0] = Object.FindObjectOfType<Particle>();

        // particleList.AddRange((IEnumerable<Particle>)FindObjectOfType<Particle>()); 

        // Debug.Log("game setting1");
    }

    private void Update()
    {
        /*
        //objelerin yak�nla�mas�n� bu �ekilde �l�ebiliyorum art�k en az�ndan circular �eyler i�in
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
        */
       //Debug.Log("Y" + closingVelocity.y);
        //Debug.Log("Z" + closingVelocity.z);
        /*
        if (fark < parGravy.radius)
        {
            Debug.Log("booom");
            
        }
        */
         
        // double k=gravy.Length;
        // parGravy.position

        // gravy[0].

        //  for (int i = 0; i < k; i++)
        // {
        //      Console.WriteLine(i);
        //  }


    }
    /*
          //  Debug.Log("game settng update giri�");
      getall.position = Vector3d.getPosition(getall.particleObject.transform.position);
    getall[0].position = Vector3d.getPosition(getall[0].particleObject.transform.position);

    */




    // Debug.Log("pos update");
    //ball.velocity.x = 5;
    //ball = Particle.integrate(0.01, ball);



}

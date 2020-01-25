using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCubito : MonoBehaviour
{
  [Header("Velocidad Movimiento")]
  public float speed = 10.0f;
  [Header("Velocidad  Rotación")]
  public float rotationSpeed = 100.0f;
  [Header("Verificación Posición")]
  public bool estoyEnElPiso = false;
  [Header("Fuerza Salto")]
  public float thrust = 1.0f;
  [Header("Acceso RigidBody")]
  public Rigidbody rb;

  public bool SegundoControl = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
      if(SegundoControl == true)
      {
      if (Input.GetKeyDown(KeyCode.Space) && estoyEnElPiso == true)
        {
            print("space key was pressed");
            rb.AddForce(transform.up * thrust);
        }
      }
      else
      {
        if (Input.GetKeyDown("g") && estoyEnElPiso == true)
          {
              print("space key was pressed");
              rb.AddForce(transform.up * thrust);
          }
        }
      }



  void Update()
  {
      if(SegundoControl == true)
      {
        float translation = Input.GetAxis("NuevoVertical") * speed;
        float rotation = Input.GetAxis("NuevoHorizontal") * rotationSpeed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(0, 0, translation);

        // Rotate around our y-axis
        transform.Rotate(0, rotation, 0);
      }
      else
      {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(0, 0, translation);

        // Rotate around our y-axis
        transform.Rotate(0, rotation, 0);
      }


  }

  void OnCollisionEnter(Collision collision)
    {


        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Ground")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Estoy en el piso hola hola hola");
            estoyEnElPiso = true;
        }

    }

    void OnCollisionExit(Collision collisionInfo)
    {

        estoyEnElPiso = false;
        print("No longer in contact with " + collisionInfo.transform.name);
    }
}

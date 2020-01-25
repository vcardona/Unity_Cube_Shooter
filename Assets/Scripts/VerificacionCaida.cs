using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificacionCaida : MonoBehaviour
{

  public GameObject UbicacionReSpawn;
  public GameObject Cubo;
  Vector3 NewPosition;

  void Start()
  {
    NewPosition = new Vector3(292.19f, -40.38f, 228.91f);
  }

  void OnTriggerEnter(Collider collision)
  {
    if(collision.gameObject.tag == "SensorCaida")
    {
      Debug.Log("Verificación de la caida del Sensor");
      Debug.Log("Cubo se ha caido");
      transform.position = NewPosition;
      transform.rotation = Quaternion.Euler(0f, 0f, 0f);

    }
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarNiveles : MonoBehaviour
{

public string scenename;

  void OnTriggerEnter(Collider collision)
  {
    if(collision.gameObject.tag == "Player")
    {
      Debug.Log("Verificación del Tag del Player");
      SceneManager.LoadScene(scenename);
    }
  }

  public void CargarEscenas(string scenename){
    SceneManager.LoadScene(scenename);
  }

  public void PlayAgain()
  {
    SceneManager.LoadScene("CubeShooter");
  }
}

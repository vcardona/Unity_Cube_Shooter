using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider mainSlider;
    public int BulletDamage;
    public GameObject Cubo;
    public GameObject myPrefab;
    public GameObject PlayerWin;
    public int totalPuntos = 0;
    public  Vector3 PosicionReSpawn;
    public int ValorMuerteWin;
    public Text PuntosKills;

    void Start()
    {
      PosicionReSpawn = new Vector3(292.19f, -40.38f, 228.91f);
    }

    void OnTriggerEnter(Collider collision)
    {
      if(collision.gameObject.tag == "Bullet" && mainSlider.value > 0)
      {
        Debug.Log("Verificación del Tag del Player");
        mainSlider.value -= BulletDamage;
      }
      else if(mainSlider.value == 0)
      {
        ReSpawn();
      }

    }

    void ReSpawn(){
      mainSlider.value = 1000;
      Instantiate(myPrefab, transform.position, transform.rotation);
      transform.position = PosicionReSpawn;
      transform.rotation = Quaternion.Euler(0f, 0f, 0f);
      totalPuntos = totalPuntos + 1;
      PuntosKills.text = totalPuntos.ToString();
      if(totalPuntos == ValorMuerteWin)
      {
        Debug.Log("Boom boro boom boom boom");
        PlayerWin.gameObject.SetActive(true);
      }
    }
}

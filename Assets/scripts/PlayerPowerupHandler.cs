using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerupHandler : MonoBehaviour
{
    public GameObject player;
    public AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;
        sound = player.GetComponent<AudioSource>();
    }

   //movment speed power up
    private void SpeedTimer()
    {
        player.GetComponent<PlayerMovementHandler>().playerMovementSpeed += 5;
       
    }
    private void SpeedTimer2()
    {
        player.GetComponent<PlayerMovementHandler>().playerMovementSpeed -= 5;
    }

   //Fire rate power up
    private void FireRateUp()
    {
        player.GetComponent<PlayerShootingHandler>().fireRate -= 100;
    }

    private void FireRateUp2()
    {
        player.GetComponent<PlayerShootingHandler>().fireRate += 100;
    }

    //private void PUMoreBullets()
    //{
    //    player.GetComponent<PlayerShootingHandler>();
    //}



   //What they do
    private void OnTriggerEnter(Collider other)
    {
        sound.Play();
        if (other.gameObject.tag == "PUSpeed")
        {
            SpeedTimer();
            Invoke("SpeedTimer2", 7f);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "PUFireRate")
        {
            FireRateUp();
            Invoke("FireRateUp2", 5f);
            Destroy(other.gameObject);
        }

        //Healing item
        if (other.gameObject.tag == "PUHealth")
        {
            player.GetComponent<PlayerDataHandler>().PlayerHealTaken(3);
            Destroy(other.gameObject);
        }

    }
}

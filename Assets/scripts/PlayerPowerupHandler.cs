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

    // Update is called once per frame
    void Update()
    {
         
    }

    private void OnTriggerEnter(Collider other)
    {
        sound.Play();
        if (other.gameObject.tag == "PUSpeed")
        {
            player.GetComponent<PlayerMovementHandler>().playerMovementSpeed *= 2;
            Destroy(other.gameObject);
        }
    }
}

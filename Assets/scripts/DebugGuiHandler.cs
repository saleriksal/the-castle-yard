using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugGuiHandler : MonoBehaviour
{
    public Canvas canvas;
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void IncreaseSpeed()
    {
        player.GetComponent<PlayerMovementHandler>().playerMovementSpeed++;
    }
    public void DecreaseSpeed()
    {
        player.GetComponent<PlayerMovementHandler>().playerMovementSpeed--;
    }
    public void IncreaseHealth()
    {
        player.GetComponent<PlayerDataHandler>().PlayerHealTaken(1);
    }
    public void DecreaseHealth()
    {
        player.GetComponent<PlayerDataHandler>().PlayerDamageTaken(1);
    }
}

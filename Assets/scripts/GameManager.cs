using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Canvas debugGui;
    private GameObject player;
    private GameObject enemySpawner;
    private bool vaweActive = false;
    public int vaweDifficulty = 0;
    public bool allEnemiesDead = false;
    private int killsNeeded;
    public int enemiesDead;
    public Animator actionBar;
    public TextMeshProUGUI actionText;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemySpawner = GameObject.FindGameObjectWithTag("EnemySpawner");
        if (debugGui.enabled == true)
        {
            debugGui.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            if (debugGui.enabled == false)
            {
                debugGui.enabled = true;
            }
            else
            {
                debugGui.enabled = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (enemiesDead == killsNeeded)
        {
            allEnemiesDead = true;
        }
        if (allEnemiesDead)
        {
            allEnemiesDead = false;
            vaweActive = false;
        }
        if (!vaweActive)
        {
            NewVawe();
        }
    }
    public void NewVawe()
    {
        vaweActive = true;
        vaweDifficulty++;
        actionText.text = "WAVE " + vaweDifficulty.ToString() + " BEGINS!";
        actionBar.SetTrigger("ActivateBar");
        enemySpawner.GetComponent<EnemySpawnHandler>().StartVaweSpawning(5, 2 + vaweDifficulty);
        killsNeeded += 5 * (2 + vaweDifficulty);
        
    }
}
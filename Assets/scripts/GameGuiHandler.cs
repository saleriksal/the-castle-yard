using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameGuiHandler : MonoBehaviour
{
    public TextMeshProUGUI kills;
    public TextMeshProUGUI wave;
    public TextMeshProUGUI clock;
    public GameObject player;
    public GameObject gameManager;
    public Image health;
    public float withd;
    public float height;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        kills.text = "0";
        wave.text = "0";
        withd = 300;
        height = 15;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        int seconds = ((int)time % 60);
        int minutes = ((int)time / 60);
        wave.text = gameManager.GetComponent<GameManager>().vaweDifficulty.ToString();
        kills.text = player.GetComponent<PlayerDataHandler>().playerKills.ToString();
        clock.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        health.rectTransform.sizeDelta = new Vector2(withd, height);
    }
}

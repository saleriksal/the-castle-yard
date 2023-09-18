using TMPro;
using UnityEngine;

public class GameGuiHandler : MonoBehaviour
{
    public TextMeshProUGUI kills;
    public TextMeshProUGUI score;
    public TextMeshProUGUI clock;
    public GameObject player;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        kills.text = "0";
        score.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        int seconds = ((int)time % 60);
        int minutes = ((int)time / 60);
        float calcScore = 0;
        calcScore = player.GetComponent<PlayerDataHandler>().playerKills * time / 2;
        int finalScore = ((int)calcScore);
        kills.text = player.GetComponent<PlayerDataHandler>().playerKills.ToString();
        clock.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        score.text = finalScore.ToString();
    }
}

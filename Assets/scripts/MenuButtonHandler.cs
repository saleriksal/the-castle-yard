using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonHandler : MonoBehaviour
{
    public Image jumpScare;
    public void PlayButton()
    {
        SceneManager.LoadScene("GameMainScene");
    }
    public void JumpScare()
    {
        jumpScare.enabled = true;
        StartCoroutine(FadeImage(true));
    }
    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                jumpScare.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                jumpScare.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}

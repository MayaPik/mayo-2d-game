using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayUI : MonoBehaviour
{
    [SerializeField]
    private Text Score;
  [SerializeField]
    private Text ScoreUI;
    [SerializeField]
    private Text Record;

  public void Update()
{
    Score.text = "Score: " + GameManager.instance.score.ToString(); 
    Record.text = "Record: " + GameManager.instance.record.ToString(); 

    if (GameManager.instance.score >= GameManager.instance.record) {
        GameManager.instance.record = GameManager.instance.score;
        ScoreUI.text = "New Record! : " + GameManager.instance.record.ToString(); 
    } else {
        ScoreUI.text = "Score: " + GameManager.instance.score.ToString(); 
    }
}


    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameManager.instance.RestartScore(); 
    }

    public void HomeButton() {
        SceneManager.LoadScene("OpenScreen");
    }
}

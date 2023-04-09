using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

   public static GameManager instance;
   public int score = 0; 
   public int record = 0; 

   [SerializeField]
   private GameObject[] players;
   private int _charIndex;
   public int CharIndex {
    get { return _charIndex; }
    set {_charIndex = value;}
   }

    public void Awake()
    {

     if (instance == null) {
        instance = this;
        DontDestroyOnLoad(gameObject);
     }   
     else {
        Destroy(gameObject);
     }
    }

    private void OnEnable() 
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnDisable() 
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) 
    {
        if (scene.name == "Game") {
            Instantiate(players[CharIndex]);
        }
    }
     public void AddScore(int points) {
        score += points;
    }

     public void RestartScore() {
        score = 0;
    }

}

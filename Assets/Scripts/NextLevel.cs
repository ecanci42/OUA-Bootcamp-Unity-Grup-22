using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextLevel : MonoBehaviour
{
    Scene scene;
    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            SceneManager.LoadScene(scene.buildIndex+1);
        }
    }

    public void StartLevel() 
    {
        SceneManager.LoadScene(scene.buildIndex + 1);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
        Score.live = 3;
        Score.totalscore = 0;
    }
}

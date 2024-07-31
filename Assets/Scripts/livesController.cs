using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class livesController : MonoBehaviour
{
    private void Awake()
    {
        switch (Score.live)
        {
            case 3:
            break;
            case 2:
                gameObject.transform.GetChild(2).gameObject.SetActive(false);
                break;
            case 1:
                gameObject.transform.GetChild(2).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
                break;
            case 0:
                SceneManager.LoadScene(4);
                break;
            default:
                break;
        }
    }
}

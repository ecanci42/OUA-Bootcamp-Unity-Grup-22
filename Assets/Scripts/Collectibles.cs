using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collectibles : MonoBehaviour
{
   public int score=0;
   AudioSource audioSource;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        scoreText.text = Score.totalscore.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            audioSource.Play();
            Destroy(collision.gameObject);
            Score.totalscore++;
            scoreText.text = Score.totalscore.ToString();

        }
       
    }
}

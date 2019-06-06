using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DestroyBullet : MonoBehaviour
{
	public Text scoretxt;
    static int score = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            score = score + 5;
            scoretxt.text = "SCORE: " + score;
            if(score >= 100)
            {
                SceneManager.LoadScene(0);
                score = 0;
            }
        }
        if(collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}

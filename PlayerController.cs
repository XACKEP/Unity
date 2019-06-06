using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{   
    Rigidbody rb;
    public Text hpText;
    int hp;
    public int speedRotation = 3;
    Rigidbody rbBullet;
    Rigidbody rbClone;
    public GameObject bullet;
    GameObject bulletClone;
    public GameObject basa;
    public GameObject enemy;
    GameObject enemyClone;
    Rigidbody rbenemy;
    Rigidbody rbClonee;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hp = 100;
    }

    void FixedUpdate()
    {   
    	float moveVertical = Input.GetAxis("Vertical");
    	rb.AddForce(transform.forward * moveVertical * 10f);
    	//Повороты влево и вправо
    	if (Input.GetKey(KeyCode.A)) 
        { 
            transform.Rotate(Vector3.down * speedRotation); 
        } 
        if (Input.GetKey(KeyCode.D)) 
        { 
            transform.Rotate(Vector3.up * speedRotation); 
        }
        if(Input.GetKeyDown("space"))
        {
            bulletClone = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1f), Quaternion.identity);
            rbClone = bulletClone.GetComponent<Rigidbody>();
            rbClone.AddForce(transform.forward * 1000f);
        }
        if(Input.GetKeyDown("f1"))
        {
            enemyClone = Instantiate(enemy, new Vector3(basa.transform.position.x, basa.transform.position.y, basa.transform.position.z + 2f), Quaternion.identity);
            rbClonee = enemyClone.GetComponent<Rigidbody>();
            rbClonee.AddForce(transform.forward * 1000f);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
    	if(collision.gameObject.tag == "Enemy")
    	{
    		hpText.text = "HP: 0";
    		hp = hp - 5;
    		hpText.text = "HP: " + hp;
    	}
        if(hp <= 0)
        {
            Destroy(gameObject);
            hpText.text = "DED";
            SceneManager.LoadScene(1);
        }
    }
}

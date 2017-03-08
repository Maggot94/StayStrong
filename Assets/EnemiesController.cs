using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemiesController : MonoBehaviour
{

	public Transform spawnPoint;

	public GameObject Enemy;






	// Use this for initialization

	void Start ()
	{
		Instantiate(Enemy, spawnPoint.position, spawnPoint.rotation);   

	}

	/*void Respawn()
    {
        if (GameObject.Find("Enemy").GetComponent<Enemy>().death)
        {
            EnemyGenerator();
        }
    }
    void EnemyGenerator()
    {
         Instantiate(Enemy, spawnPoint.position, spawnPoint.rotation);
    }
    */

}

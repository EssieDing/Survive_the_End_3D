using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    int hurt = 20;
    float attack_time = 0;
    public AudioClip AC;
	public GameObject Player;

    void Update()
    {
		if (attack_time <= 0 && Vector3.Distance(transform.position, Player.transform.position) <= 2)
		{
			Player.SendMessage("TakeDamage", hurt);
			attack_time = 2;
			//AudioSource.PlayClipAtPoint(AC, transform.localPosition);
			this.GetComponent<AudioSource>().PlayOneShot(AC);
		}
		else
		{
			attack_time -= Time.deltaTime;
		}

    }

}

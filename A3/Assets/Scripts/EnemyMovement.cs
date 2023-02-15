using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    public Transform playerTarget;
    //private Vector3[] basePosition = new Vector3()[];
    public Terrain terrain;
    UnityEngine.AI.NavMeshAgent agent;
    public float currentSpeed;
    public bool findingBase = false;
    public GameObject enemyPrefab;
    private float timer =2f;
    private GameObject clone;


    // Use this for initialization
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.SetDestination(playerTarget.position);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        searchDestination();
        // 
        // currentSpeed = agent.speed;        
        if (agent.speed < 14f && timer <= 0) {
            agent.speed = 1.001f * agent.speed;
        } else if (agent.speed >= 14f) {
            agent.speed = 14f;
        }
        generatePrefab();
        if (PlayerSkills.skilled == true) {
            
        } else if (!findingBase) { // change state if has found base
            agent.SetDestination(playerTarget.position);
        }
    }


    public void searchDestination() {
        
        foreach (GameObject instance in terrain.baseGroup) {
            Vector3 basePosition = instance.GetComponent<Transform>().position;
            float distance = Vector3.Distance(basePosition, this.transform.position);
            // if (distance < 20 ) {
            //     agent.SetDestination(basePosition);
            //  } else {
            //     agent.SetDestination(playerTarget.position);
            //  }
             //else if (Vector3.Distance(basePosition, transform.position) >= 10) {
            //     agent.SetDestination(playerTarget.position);
            // }
            if (distance > 1 && distance <= 8 && !instance.GetComponent<Base>().enemyFound && !findingBase) {
                findingBase = true;
                agent.SetDestination(basePosition);
            }
        }
    }

    public void generatePrefab(){
        if (!agent.pathPending && agent.remainingDistance < agent.stoppingDistance && findingBase){ // in the state of finding base
            AppManager.enemyNum += 1;
            //AppManager.enemyNumText.text = AppManager.enemyNum.ToString();
            
            Debug.Log ("BaseFound: Decrease Speed");
            clone = Instantiate(enemyPrefab, this.transform.position, Quaternion.identity);
            //clone = Instantiate(enemyPrefab);
            clone.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 0.5f * agent.speed;
            agent.speed = 0.9f * agent.speed;
            findingBase = false;
        }
    }


}

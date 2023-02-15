using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : MonoBehaviour
{
    private GameObject plane;
    public AudioClip coinAudio;

    // Start is called before the first frame update
    void Start()
    {
        plane = GameObject.Find("Plane");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Time.deltaTime, 0);
        transform.Rotate(0, 30 * Time.deltaTime, 0, Space.World);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            this.GetComponent<AudioSource>().PlayOneShot(coinAudio);
            Debug.Log("OnTriggerEnter()");
            AppManager.scoreNum += 5;
            
            plane.GetComponent<Terrain>().itemGroup.Remove(this.gameObject);
            Destroy(this.gameObject, 0.3f);
        }
    }
}

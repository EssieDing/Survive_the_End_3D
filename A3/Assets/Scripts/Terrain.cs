using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    public GameObject floorPrefab;
    public GameObject hillPrefab;
    public GameObject itemPrefab;
    public GameObject dangerousPrefab;
    public GameObject basePrefab;
    public GameObject parentObject;
    public static int[,] map = new int[101, 101];
    public int itemNumber = 15;
    public int dangerousNumber = 15;
    public int baseNumber = 30;
    public float timer = 20f;

    public List<GameObject> dangerousGroup = new List<GameObject>();
    public List<GameObject> itemGroup = new List<GameObject>();
    public List<GameObject> baseGroup = new List<GameObject>();
    //public int[] timeCount = new int[10]{60, 60, 60, 60, 60, 60, 60, 60, 60, 60};



    // Start is called before the first frame update
    void Start()
    {
        //Generate floor
        for (int i= -50; i< 50; i++) {
            for (int j= -50; j<50; j++) {
                map [i+50, j+50] = 1; // default floor as 1
            }
        }

        while (dangerousNumber != 0) {
            int xRandom = Random.Range(-49, 49);
            int zRandom = Random.Range(-49, 49);
            generateDangerousMap(xRandom, zRandom);
        }


        for (int i= -50; i< 50; i++) {
            for (int j= -50; j< 50; j++) {
                if (map [i+50, j+50] == 1){
                    Instantiate(floorPrefab, new Vector3(i, 0, j), Quaternion.identity, this.transform);
                }else if (map [i+50, j+50] == -1){
                    dangerousGroup.Add (Instantiate(dangerousPrefab, new Vector3(i, 0, j), Quaternion.identity, this.transform));
                }
            }
        }

        //Generate Items
        for (int i=1; i<= itemNumber; i++) {
            generateNewItem();
        }

        //Generate bases
        for (int i=1; i<= baseNumber; i++) {
            generateBases();
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (itemGroup.Count < itemNumber) {
            if (timer <= 0) {
                generateNewItem();
                timer = 20f;
            }
        }

    }

    public void generateDangerousMap(int xRandom, int zRandom){
        if (map [xRandom +50, zRandom +50] == 1 && map [xRandom +49, zRandom +50] == 1 && map [xRandom +51, zRandom +50] == 1
            && map [xRandom +50, zRandom +49] == 1 && map [xRandom +49, zRandom +49] == 1 && map [xRandom +51, zRandom +49] == 1
            && map [xRandom +50, zRandom +51] == 1 && map [xRandom +49, zRandom +51] == 1 && map [xRandom +51, zRandom +51] == 1){
                
                // change all nine planes around the middle point
                map [xRandom +50, zRandom +50] = -1; // dangerous area as -1
                map [xRandom +49, zRandom +50] = -1;
                map [xRandom +51, zRandom +50] = -1;
                map [xRandom +50, zRandom +49] = -1; // dangerous area as -1
                map [xRandom +49, zRandom +49] = -1;
                map [xRandom +51, zRandom +49] = -1;
                map [xRandom +50, zRandom +51] = -1; // dangerous area as -1
                map [xRandom +49, zRandom +51] = -1;
                map [xRandom +51, zRandom +51] = -1;
                dangerousNumber --;
            }
    }


    public void generateNewItem(){
        //Debug.Log ("GenerateNewOne");
        int xRandom = Random.Range(-50, 50);
        int zRandom = Random.Range(-50, 50);
        if (map [xRandom +50, zRandom +50] == 1) {
                map [xRandom +50, zRandom +50] += 1; // money as 2
                itemGroup.Add(Instantiate(itemPrefab, new Vector3(xRandom, 1, zRandom), Quaternion.identity, parentObject.transform));
        }           
    }

    public void generateBases(){
        int xRandom = Random.Range(-50, 50);
        int zRandom = Random.Range(-50, 50);
        if (map [xRandom +50, zRandom +50] == 1) {
                map [xRandom +50, zRandom +50] = 0; // bases as 0
                baseGroup.Add(Instantiate(basePrefab, new Vector3(xRandom, 0.5f, zRandom), Quaternion.identity, parentObject.transform));
        }           
    }

}

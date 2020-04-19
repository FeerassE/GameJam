using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{


    public int points = 0;
    public GameObject memorySpawner;
    public GameObject emotionToTest;
    public Vector2 size;
    public float width;
    public float height;
    void Start() {
        memorySpawner = GameObject.Find("RecipeSpawner");
        size = gameObject.GetComponent<SpriteRenderer>().size; 
        width = size.x;
        height = size.y;   
    } 
    void OnTriggerEnter2D(Collider2D coll)
    {   
        if(coll.gameObject.tag == "emotion") {
            if(coll.gameObject.GetComponent<Memory>().type == memorySpawner.GetComponent<MemorySpawner>().activeMemories.Peek().GetComponent<Memory>().type) {
                memorySpawner.GetComponent<MemorySpawner>().activeMemories.Dequeue();
                points++;
                gameObject.transform.localScale += new Vector3(width + 1, height + 1, 0);
                Destroy(coll.gameObject);
            }
            if(coll.gameObject) {
                Destroy(coll.gameObject);
            }
        }
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
}

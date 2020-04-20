using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collector : MonoBehaviour
{
    public int points = 0;
    public GameObject memorySpawner;
    public Vector2 size;
    public GameObject door;

    private float width;
    private float height;

    public float scale = 0;
    public float shrinkSpeed = 2.0f;
    public float shrinkAmount = 0.4f;
    public bool endCondition = false;

    /* which xvalue of the collector's scale will trigger a game over */
    public int gameOverValue = 1;
    public int timesShrunk = 0;

    private int doorCount = 0;

    void Start() {
        memorySpawner = GameObject.Find("EmotionSpawner");
        size = gameObject.GetComponent<SpriteRenderer>().size; 
        width = size.x;
        height = size.y;

        /* shrinks at shrinkspeed starting in 5 seconds*/
        InvokeRepeating("ShrinkCollector", 15.0f,  shrinkSpeed);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {   
        if(coll.gameObject.tag == "emotion") {
            if(memorySpawner.GetComponent<MemorySpawner>().activeMemories.Count > 0) {
                if(coll.gameObject.GetComponent<Memory>().type == memorySpawner.GetComponent<MemorySpawner>().activeMemories.Peek().GetComponent<Memory>().type) {
                    Destroy(memorySpawner.GetComponent<MemorySpawner>().activeMemories.Dequeue());
                    foreach(GameObject memory in memorySpawner.GetComponent<MemorySpawner>().activeMemories)
                    {
                        memory.transform.position = new Vector3(memory.transform.position.x -1, memory.transform.position.y, 0);
                    }
                    points++;
                    gameObject.transform.localScale += new Vector3(width + 1, height + 1, 0);
                    Destroy(coll.gameObject);
                }
            }
            if(coll.gameObject) {
                Destroy(coll.gameObject);
            }
        }
    }

    /* shrinks the collector */
    void ShrinkCollector() {
        gameObject.transform.localScale += new Vector3(width - shrinkAmount, height - shrinkAmount, 0);
        timesShrunk++;
    }

    void Update()
    {
        scale = gameObject.transform.localScale.x;
        /* GAME OVER CONDITION */
        if (gameObject.transform.localScale.x < gameOverValue) {
            SceneManager.LoadScene("GameOver");
        }

        /* Win condition */
        if(gameObject.transform.localScale.x > 38.0f && doorCount < 1)
        {
            doorCount++;
            GameObject a = (GameObject)Instantiate(door, new Vector3(-16.999f, -3.26f), Quaternion.identity);
        }

    }


}

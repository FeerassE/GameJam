using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemorySpawner : MonoBehaviour
{
    public GameObject happy;
    public GameObject sad;
    public GameObject angry;
    public GameObject depression;
    public GameObject anxiety;
    public GameObject empathy;

    public float respawnTime;
    public int recipeLength = 6;
    public List<GameObject> memoryOrder = new List<GameObject>();
    public Queue<GameObject> activeMemories = new Queue<GameObject>();

    public System.Random r;
    void Start()
    {
        r = new System.Random();
        
        memoryOrder.Add(happy);
        memoryOrder.Add(sad);
        memoryOrder.Add(angry);
        memoryOrder.Add(depression);
        memoryOrder.Add(anxiety);
        memoryOrder.Add(empathy);
        spawnMemory();
        StartCoroutine(memories());
    }

    public void spawnMemory()
    {   
        int randomNum = r.Next(0,5);
        GameObject tmp = memoryOrder[randomNum];
        int activeLength = activeMemories.Count;
        GameObject a = (GameObject)Instantiate(tmp, new Vector3(transform.position.x + activeLength, transform.position.y, transform.position.z), Quaternion.identity);
        activeMemories.Enqueue(a);
    }

    IEnumerator memories()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            if((activeMemories.Count != recipeLength) && (activeMemories.Count < 6)) {
                spawnMemory();
            }
            
        }
    }
}

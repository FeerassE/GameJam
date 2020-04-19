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
    public float respawnTime = 5.0f;
    public Queue<GameObject> numbers = new Queue<GameObject>();
    public Queue<GameObject> activeMemories = new Queue<GameObject>();

    void Start()
    {
        
        numbers.Enqueue(happy);
        numbers.Enqueue(sad);
        numbers.Enqueue(angry);
        numbers.Enqueue(depression);
        numbers.Enqueue(anxiety);
        numbers.Enqueue(empathy);
        spawnMemory();
        StartCoroutine(memories());
    }

    public void spawnMemory()
    {
        GameObject tmp = numbers.Dequeue();
        GameObject a = (GameObject)Instantiate(tmp, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        activeMemories.Enqueue(a);
        foreach (GameObject activeMemory in activeMemories)
        {
            activeMemory.transform.localPosition = new Vector3(activeMemory.transform.position.x + 1, activeMemory.transform.position.y);
        }
    }

    IEnumerator memories()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnMemory();
        }
    }
}

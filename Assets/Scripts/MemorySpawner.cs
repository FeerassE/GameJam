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
    public int recipeLength = 5;
    public List<GameObject> numbers = new List<GameObject>();
    public Queue<GameObject> activeMemories = new Queue<GameObject>();

    public System.Random r;
    void Start()
    {
        r = new System.Random();
        
        numbers.Add(happy);
        numbers.Add(sad);
        numbers.Add(angry);
        numbers.Add(depression);
        numbers.Add(anxiety);
        numbers.Add(empathy);
        spawnMemory();
        StartCoroutine(memories());
    }

    public void spawnMemory()
    {   
        int randomNum = r.Next(0,5);
        GameObject tmp = numbers[randomNum];
        int activeLength = activeMemories.Count;
        GameObject a = (GameObject)Instantiate(tmp, new Vector3(transform.position.x + activeLength, transform.position.y, transform.position.z), Quaternion.identity);
        activeMemories.Enqueue(a);
    }

    private void fillNumbers() {

    }

    IEnumerator memories()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            if((activeMemories.Count != recipeLength) && (activeMemories.Count < 5)) {
                spawnMemory();
            }
            
        }
    }
}

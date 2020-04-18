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
    public Stack<GameObject> numbers = new Stack<GameObject>();

    void Start()
    {
        
        numbers.Push(happy);
        numbers.Push(sad);
        numbers.Push(angry);
        numbers.Push(depression);
        numbers.Push(anxiety);
        numbers.Push(empathy);
        spawnMemory();
        StartCoroutine(memories());
    }

    public void spawnMemory()
    {
        GameObject a = (GameObject)Instantiate(numbers.Pop(), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
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

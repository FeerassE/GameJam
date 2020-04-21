using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionBucket : MonoBehaviour
{
    public GameObject bucket;
    // Start is called before the first frame update
    void Start()
    {
        GameObject a = (GameObject)Instantiate(bucket, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "emotion") {
            StartCoroutine(memories());
        }
    }

    IEnumerator memories()
    {
        yield return new WaitForSeconds(1.0f);
        GameObject a = (GameObject)Instantiate(bucket, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

    }
}

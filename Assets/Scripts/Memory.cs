using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        if (this.transform.position.x > 50)
            Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeHolder : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BirdController.instance!=null && !BirdController.instance.isAlive)
        {
            Destroy(GetComponent<PipeHolder>());
        }
        _Move();
    }

    void _Move() {
        Vector3 vector3 = transform.position;
        vector3.x -= speed * Time.deltaTime;

        transform.position = vector3;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }
}

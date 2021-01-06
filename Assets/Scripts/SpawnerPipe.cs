using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPipe : MonoBehaviour
{
    public float minY, maxY;

    [SerializeField]
    private GameObject pipeHolder;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator _Spawner()
    {
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        Vector3 position = pipeHolder.transform.position;

        position.y = Random.Range(minY, maxY);

        Instantiate(pipeHolder, position, Quaternion.identity);
        StartCoroutine(_Spawner());
    }

    
}

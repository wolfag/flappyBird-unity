using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Vector3 vector3 = transform.localScale;

        float h = spriteRenderer.bounds.size.y;
        float w = spriteRenderer.bounds.size.x;

        float worldH = Camera.main.orthographicSize * 2f;
        float worldW = worldH * Screen.width / Screen.height;

        vector3.y = worldH / h;
        vector3.x = worldW / w;

        transform.localScale = vector3;
    }
}

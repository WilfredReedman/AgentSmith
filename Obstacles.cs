using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    float red = 0;
    public float speed;
    private void Update()
    {
        if (transform.position.y - transform.localScale.y - 10f > Camera.main.transform.position.y)
            Destroy(gameObject);
        if (red < 0.625f)
            red += Time.deltaTime * speed;
        else red = 0.625f;
        GetComponent<Renderer>().material.SetColor("_Color", new Color(red, 0, 0));
    }
}

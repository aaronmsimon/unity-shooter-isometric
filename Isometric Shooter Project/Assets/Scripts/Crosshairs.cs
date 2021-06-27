using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshairs : MonoBehaviour
{
    public LayerMask targetMask;
    public SpriteRenderer dot;
    public Color dotHighlightColor;
    Color originalDotColor;

    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        originalDotColor = dot.color;

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * -40 * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Escape) && player != null)
        {
            Cursor.visible = !Cursor.visible;
        }
        if(player == null)
        {
            Cursor.visible = true;
        }
    }

    public void DetectTargets(Ray ray)
    {
        if (Physics.Raycast(ray, 100, targetMask))
        {
            dot.color = dotHighlightColor;
        } else
        {
            dot.color = originalDotColor;
        }
    }

}

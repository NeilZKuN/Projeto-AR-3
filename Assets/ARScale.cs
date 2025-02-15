using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARScale : MonoBehaviour
{
    public Vector3 scale;
    public float scaleDistance;

    public GameObject obj;

    private float startDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100))
            {
                obj = hit.transform.gameObject;
            }

            if (Input.touchCount >= 2) 
            {
                Touch touch0 = Input.GetTouch(0);
                Touch touch1 = Input.GetTouch(1);

                if (touch0.phase == TouchPhase.Began || touch1.phase == TouchPhase.Began)
                {
                    startDistance = Vector2.Distance(touch0.position, touch1.position);
                    scale = obj.transform.localScale;
                }
                else
                {
                    Vector2 v0 = touch0.position;
                    Vector2 v1 = touch1.position;

                    float distance = Vector2.Distance(v0, v1);
                    float factor = distance / startDistance;

                    obj.transform.localScale = scale * factor;
                }
            }
        }
    }
}

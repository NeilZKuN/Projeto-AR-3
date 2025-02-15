using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARTouch : MonoBehaviour
{
    public GameObject pokedexEntry;
    public Animator anim;

    private bool hasImage = false;

    void Update()
    {
        // Handle both mouse clicks (for testing in the editor) and touch input (for mobile)
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Debug.Log("Pressed primary button or touched screen.");

            // Use correct position depending on input method
            Vector3 inputPosition = Input.mousePosition;
            if (Input.touchCount > 0)
            {
                inputPosition = Input.GetTouch(0).position;
            }

            Ray ray = Camera.main.ScreenPointToRay(inputPosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log("Hit detected: " + hit.transform.name + " : " + hit.transform.tag);

                if (hit.transform.CompareTag("mushroom"))
                {
                    Debug.Log("mushroom hit!");
                    Vector3 pos = hit.transform.position + new Vector3(0f, -0.1f, 0f);
                    //pos.z += 0.25f;
                    //pos.y += 0.25f;
                    Debug.Log(hit.transform.position);
                    if (hasImage == false) 
                    {
                        // Instantiate(pokedexEntry, pos, Quaternion.identity);
                        hasImage = true;
                    }

                    anim = hit.transform.GetComponentInChildren<Animator>();
                    anim.SetTrigger("hasTouched");
                    
                }

                if (hit.transform.CompareTag("pokedex"))
                {
                    Destroy(hit.transform.gameObject);
                    hasImage = false;
                }
            }
        }
    }
}

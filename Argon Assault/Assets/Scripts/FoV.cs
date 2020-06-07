using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoV : MonoBehaviour
{
    Camera camera;
    float waitTimer = 0.05f;
    [SerializeField] bool zoomIn = true;
    float zoomSpeed = 0.05f;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        camera = GetComponent<Camera>();

        do
        {
            if (zoomIn == true)
            {
                yield return StartCoroutine(ZoomIn());
            }
            else
            {
                yield return StartCoroutine(ZoomOut());
            }
        }

        while (true);
    }
    
    IEnumerator ZoomIn()
    {
        if (camera.fieldOfView < 150)
        {
            zoomIn = false;
            zoomSpeed = 0.02f;
        }
        yield return new WaitForSeconds(waitTimer);
        camera.fieldOfView= camera.fieldOfView- zoomSpeed;
    }

    IEnumerator ZoomOut()
    {
        if (camera.fieldOfView > 155) zoomIn = true;
        yield return new WaitForSeconds(waitTimer);
        camera.fieldOfView= camera.fieldOfView + zoomSpeed;
    }
}

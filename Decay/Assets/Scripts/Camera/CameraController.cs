using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject cameraTarget;


    public Transform cameraBoundLeft;
    public Transform cameraBoundRight;
    public Transform cameraBoundTop;
    public Transform cameraBoundBottom;

    private void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = GetComponent<Camera>();
        }

    }


    float timer = 0;
    private void Update()
    {
        //if (timer >= 0.5f)
        //{
        //    timer = 0f;
        //    if (colorGrading.saturation.value == 100f)
        //    {
        //        colorGrading.saturation.value = -100f;
        //    }
        //    else
        //    {
        //        colorGrading.saturation.value = 100f;
        //    }
        //}

        //colorGrading.saturation.value = Mathf.Sin(Time.time * 5)  * 100;

        float saturation = Mathf.Sin(Time.time) * 100;

        //saturation = -500f;

        saturation = Mathf.Min(Mathf.Max(saturation, -100f), 100f);
//colorGrading.saturation.value = saturation;

        float intensity = (Mathf.Sin(Time.time) + 1f) / 2f;
        intensity = Mathf.Min(Mathf.Max(intensity, 0.4f), 1f); 
        //vignette.intensity.value = intensity;

        //timer += Time.deltaTime;
    }

    private void LateUpdate()
    {
        Vector3 newPosition = mainCamera.transform.position;

        if (cameraTarget != null)
        {
            newPosition.x = cameraTarget.transform.position.x;
            newPosition.y = cameraTarget.transform.position.y;
        }

        float halfHeight = mainCamera.orthographicSize;
        float halfWidth = mainCamera.aspect * halfHeight;

        if (cameraTarget.transform.position.x < cameraBoundLeft.position.x + halfWidth)
        {
            newPosition.x = cameraBoundLeft.position.x + halfWidth;
        }

        if(cameraTarget.transform.position.x > cameraBoundRight.position.x - halfWidth)
        {
            newPosition.x = cameraBoundRight.position.x - halfWidth;
        }

        if(cameraTarget.transform.position.y < cameraBoundBottom.position.y + halfHeight)
        {
            newPosition.y = cameraBoundBottom.position.y + halfHeight;
        }

        if (cameraTarget.transform.position.y > cameraBoundTop.position.y - halfHeight)
        {
            newPosition.y = cameraBoundTop.position.y - halfHeight;
        }

        mainCamera.transform.position = newPosition;
    }
}

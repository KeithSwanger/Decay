using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Rendering.PostProcessing;
public class CameraController : MonoBehaviour
{
    public Camera Camera;
    public GameObject cameraTarget;
    public PostProcessVolume postProcess;
    public ColorGrading colorGrading;
    public Vignette vignette;
    public Grain grain;


    private void Start()
    {
        if (Camera == null)
        {
            Camera = GetComponent<Camera>();
        }

        if (postProcess == null)
        {
            postProcess = GetComponent<PostProcessVolume>();
        }

        colorGrading = (ColorGrading)postProcess.profile.settings.Find(x => x.GetType() == typeof(ColorGrading));
        vignette = (Vignette)postProcess.profile.settings.Find(x => x.GetType() == typeof(Vignette));
        grain = (Grain)postProcess.profile.settings.Find(x => x.GetType() == typeof(Grain));


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
        colorGrading.saturation.value = saturation;

        float intensity = (Mathf.Sin(Time.time) + 1f) / 2f;
        intensity = Mathf.Min(Mathf.Max(intensity, 0.4f), 1f); 
        vignette.intensity.value = intensity;

        //timer += Time.deltaTime;
    }

    private void LateUpdate()
    {
        if (cameraTarget != null)
        {
            Camera.transform.position = new Vector3(cameraTarget.transform.position.x, cameraTarget.transform.position.y, Camera.transform.position.z);
        }
    }
}

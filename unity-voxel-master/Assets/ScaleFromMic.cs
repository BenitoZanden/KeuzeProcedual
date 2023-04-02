using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VoxelSystem.Demo;

public class ScaleFromMic : MonoBehaviour
{
    public AudioSource source;
    public Vector3 minScale;
    public Vector3 maxScale;
    public MicTest detector;

    public float smoothLoudness;
    public float smoothCriminal;

    public float loudnessSensibility = 100;
    public float treshhold = 0.1f;


    public GPUVoxelParticleSystem voxelParticle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float loudness = detector.GetLoundnessFromMicrophone() * loudnessSensibility;
        smoothLoudness = Mathf.Lerp(smoothLoudness, loudness, smoothCriminal * Time.deltaTime);
        smoothLoudness = Mathf.Clamp(smoothLoudness, 0, 1);

        if (loudness < treshhold)
        {
            loudness = 0;
        }

        //transform.localScale = Vector3.Lerp(minScale, maxScale, loudness);
        float invertedScream = -smoothLoudness + 1f;
        voxelParticle.threshold = invertedScream;
    }
}

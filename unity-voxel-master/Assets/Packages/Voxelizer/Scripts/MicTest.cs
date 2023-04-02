using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicTest : MonoBehaviour
{

    public int sampleWindow = 64;

    private AudioClip micClip;

    // Start is called before the first frame update
    void Start()
    {
        MicToAudio();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MicToAudio() 
    {
        string micName = Microphone.devices[0];
        micClip = Microphone.Start(micName, true, 20, AudioSettings.outputSampleRate);
    }

    public float GetLoundnessFromMicrophone()
    {
        return GetSound(Microphone.GetPosition(Microphone.devices[0]), micClip);
    }


    public float GetSound(int clipPosition, AudioClip clipName) 
    {
        int startPosition = clipPosition - sampleWindow;

        if (startPosition < 0) 
        {
            return 0;
        }

        float[] waveData = new float[sampleWindow];
        clipName.GetData(waveData, startPosition);

        float totalLoud = 0;
        for (int i = 0; i < sampleWindow; i++) 
        {
            totalLoud += Mathf.Abs(waveData[i]);
        }

        return totalLoud / sampleWindow;
    }
}

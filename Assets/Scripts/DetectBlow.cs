using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectBlow : MonoBehaviour
{
    public float rmsVal;
    public float dbVal;
    public float pitchVal;

    private static DetectBlow instance;

    private const int QSamples = 1024;
    private const float RefValue = 0.1f;
    private const float Threshold = 0.02f;

    float[] _samples;
    private float[] _spectrum;
    private float _fSample;

    private AudioSource _audio;

    private bool blowDetected = false;

    public bool BlowDetected { get => blowDetected; set => blowDetected = value; }
    public static DetectBlow Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<DetectBlow>();
            return instance;
        }
    }

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    void Start()
    {
        _samples = new float[QSamples];
        _spectrum = new float[QSamples];
        _fSample = AudioSettings.outputSampleRate;

        _audio.clip = Microphone.Start(null, true, 10, 44100);
        _audio.loop = true;
        _audio.mute = false;
        while (!(Microphone.GetPosition(null) > 0)) { }
        _audio.Play();
    }

    void Update()
    {
        AnalyzeSound();

        if(
            (rmsVal > 0.2) &&
            (dbVal > 6f) &&
            (pitchVal > 200)
            )
        {
            blowDetected = true;
        }
        else
        {
            blowDetected = false;
        }

        //Debug.Log("RMS: " + rmsVal.ToString("F2"));
        //Debug.Log(dbVal.ToString("F1") + " dB");
        //Debug.Log(pitchVal.ToString("F0") + " Hz");

        
    }

    private void OnGUI()
    {
        GUI.skin.label.fontSize = Screen.width / 20;
        GUILayout.Label("RMS: " + rmsVal.ToString("F2"));
        GUILayout.Label(dbVal.ToString("F1") + " dB");
        GUILayout.Label(pitchVal.ToString("F0") + " Hz");
    }

    void AnalyzeSound()
    {
        _audio.GetOutputData(_samples, 0); // fill array with samples
        int i;
        float sum = 0;
        for (i = 0; i < QSamples; i++)
        {
            sum += _samples[i] * _samples[i]; // sum squared samples
        }
        rmsVal = Mathf.Sqrt(sum / QSamples); // rms = square root of average
        dbVal = 20 * Mathf.Log10(rmsVal / RefValue); // calculate dB
        if (dbVal < -160) dbVal = -160; // clamp it to -160dB min
                                        // get sound spectrum
        _audio.GetSpectrumData(_spectrum, 0, FFTWindow.BlackmanHarris);
        float maxV = 0;
        var maxN = 0;
        for (i = 0; i < QSamples; i++)
        { // find max 
            if (!(_spectrum[i] > maxV) || !(_spectrum[i] > Threshold))
                continue;

            maxV = _spectrum[i];
            maxN = i; // maxN is the index of max
        }
        float freqN = maxN; // pass the index to a float variable
        if (maxN > 0 && maxN < QSamples - 1)
        { // interpolate index using neighbours
            var dL = _spectrum[maxN - 1] / _spectrum[maxN];
            var dR = _spectrum[maxN + 1] / _spectrum[maxN];
            freqN += 0.5f * (dR * dR - dL * dL);
        }
        pitchVal = freqN * (_fSample / 2) / QSamples; // convert index to frequency
    }
}

using UnityEngine;
using UnityEngine.Events;

public class BeatManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float _bpm;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Intervals[] intervals;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Intervals interval in intervals)
        {
            float sampleTime = (_audioSource.timeSamples / (_audioSource.clip.frequency * interval.GetIntervalLength(_bpm))); // Get the current time of the audio source
            interval.CheckAndTrigger(sampleTime); // Check and trigger the event based on the current time
        }
    }
}

[System.Serializable]
public class Intervals
{
    [SerializeField] public float _steps; // Time in seconds when the event should be triggered
    [SerializeField] public UnityEvent _trigger; // Event to be triggered at the specified time
    private int _LastInverval;

    public float GetIntervalLength(float bpm)
    {
        return 60f / (bpm * _steps); // Calculate the interval length based on BPM and steps
    }
    public void CheckAndTrigger(float interval)
    {
        if (Mathf.FloorToInt(interval) != _LastInverval)
        {
            _LastInverval = Mathf.FloorToInt(interval); // Update the last interval
            _trigger.Invoke(); // Trigger the event
        }
    }
}
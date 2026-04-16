using UnityEngine;
using System.Collections;

public class PulseToBeat : MonoBehaviour
{
    [SerializeField] bool _useTestBeat;
    [SerializeField] float _pulseSize = 1.15f;
    [SerializeField] float _returnspeed = 5f;
    private Vector3 _startSize;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _startSize = transform.localScale;
        if (_useTestBeat)
        {
            StartCoroutine(TestBeat());
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, _startSize, _returnspeed * Time.deltaTime);
    }
    public void Pulse()
    {
        transform.localScale = _startSize * _pulseSize; // Scale the object up by the pulse size
    }

    IEnumerator TestBeat()
    {
        while (true)
        {
            Pulse();
            yield return new WaitForSeconds(1f); // Wait for 1 seconds before pulsing again
        }
    }
}

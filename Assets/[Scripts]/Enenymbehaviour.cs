using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enenymbehaviour : MonoBehaviour
{
    public Boundray horizontalSpeedRange;
    public Boundray horizontalBoundray;
    public Boundray verticalBoundray;
    private float horizontalSpeed;
    // Start is called before the first frame update
    void Start()
    {
        var RandomXPostion = Random.Range(horizontalBoundray.min, horizontalBoundray.max);
        var RandomYPostion = Random.Range(verticalBoundray.min, verticalBoundray.max);
        horizontalSpeedRange.min = Random.Range(0.5f, 2.0f);
        horizontalSpeedRange.max = Random.Range(2.0f, 6.0f);
        horizontalSpeed = Random.Range(horizontalSpeedRange.min, horizontalSpeedRange.max);
        transform.position = new Vector3(RandomXPostion, RandomYPostion, 0.0f);

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalLength = horizontalBoundray.max - horizontalBoundray.min;
        transform.position = new Vector3(Mathf.PingPong(Time.time * horizontalSpeed, horizontalLength) - horizontalBoundray.max, 
                                         transform.position.y, 
                                         transform.position.z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeButtonScript : MonoBehaviour {


    public bool shouldBreathe = false;


    private float _currentScale = InitScale;
    private const float TargetScale = 1.3f;
    private const float InitScale = 1f;
    private const int FramesCount = 100;
    private const float AnimationTimeSeconds = 1.5f;
    private float _deltaTime = AnimationTimeSeconds / FramesCount;
    private float _dx = (TargetScale - InitScale) / FramesCount;
    private bool _upScale = true;

    private IEnumerator Breath()
    {
        while (true)
        {
            if (shouldBreathe)
            {
                while (_upScale)
                {
                    _currentScale += _dx;
                    if (_currentScale > TargetScale)
                    {
                        _upScale = false;
                        _currentScale = TargetScale;
                    }
                    this.transform.localScale = Vector3.one * _currentScale;
                    yield return new WaitForSeconds(_deltaTime);
                }

                while (!_upScale)
                {
                    _currentScale -= _dx;
                    if (_currentScale < InitScale)
                    {
                        _upScale = true;
                        _currentScale = InitScale;
                    }
                    this.transform.localScale = Vector3.one * _currentScale;
                    yield return new WaitForSeconds(_deltaTime);
                }
            }
            else
            {
                yield return new WaitForSeconds(_deltaTime);
            }
        }
    }
    // Use this for initialization
    void Start () {

        StartCoroutine(Breath());
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    
}

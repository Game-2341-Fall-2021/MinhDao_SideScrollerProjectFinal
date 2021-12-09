using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flaganimationcontrol : MonoBehaviour
{
    public int frame = 0;
    public Sprite[] idleAnimation;
    public SpriteRenderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(changeframe()); 
    }
    IEnumerator changeframe()
    {
        _renderer.sprite = idleAnimation[frame];
        yield return new   WaitForSeconds(.1f);
        frame++;
        if(frame>= idleAnimation.Length)
        {
            frame = 0;
        }
        StartCoroutine(changeframe());
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}

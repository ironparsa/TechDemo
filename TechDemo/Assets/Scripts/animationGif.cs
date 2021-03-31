using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class animationGif : MonoBehaviour
{

    public Sprite[] animatedImages;
    public Image animateImage0bj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animateImage0bj.sprite = animatedImages[(int)(Time.time*10)%animatedImages.Length];

    }
}

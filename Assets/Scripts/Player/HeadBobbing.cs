using UnityEngine;
using System.Collections;
 
public class HeadBobbing : MonoBehaviour
{
    public float bobbingSpeed = 0.18f;
    public float bobbingHeight = 0.2f;
    public float midpoint = 1.8f;
    public bool isHeadBobbing = true;
 
    private float timer = 0.0f;
 
    void Update()
    {
        float waveslice = 0.0f;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
 
        Vector3 cSharpConversion = transform.localPosition;
 
        if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0)
        {
            timer = 0.0f;
        }
        else
        {
            waveslice = Mathf.Sin(timer);
            timer = timer + bobbingSpeed;
            if (timer > Mathf.PI * 2)
            {
                timer = timer - (Mathf.PI * 2);
            }
        }
        if (waveslice != 0)
        {
            float translateChange = waveslice * bobbingHeight;
            float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
            totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
            translateChange = totalAxes * translateChange;
            if(isHeadBobbing == true)
            {
                cSharpConversion.y = midpoint + translateChange;
            } else if(isHeadBobbing == false)
            {
                cSharpConversion.x = translateChange;
            }
            
        }
        else
        {
            if(isHeadBobbing == true)
            {
                cSharpConversion.y = midpoint;
            } else if(isHeadBobbing == false)
            {
                cSharpConversion.x = 0;
            }
        }
 
        transform.localPosition = cSharpConversion;
    }
}
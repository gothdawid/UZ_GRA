using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateBG : MonoBehaviour
{
    public float speedX = 0.1f;
    public float speedY = 0.1f;
    public float animateWidth = 0.3f;

    private float SC_width;
    private float SC_height;

    private void FixedUpdate()
    {
        SC_width = Screen.width;
        SC_height = Screen.height;

        Vector2 pos = this.transform.localPosition;

        float x_max_pos = SC_width * animateWidth;
        float y_max_pos = SC_height * animateWidth;


        if (System.Math.Abs(pos.x) > x_max_pos) speedX *= -1f;
        if (System.Math.Abs(pos.y) > y_max_pos) speedY *= -1f;

        this.transform.localPosition = new Vector2(pos.x + speedX, pos.y + speedY);
    }
}

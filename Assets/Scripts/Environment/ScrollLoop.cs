using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollLoop : MonoBehaviour
{
    public Renderer bgRenderer;

    // Update is called once per frame
    void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(GameSpeed.speed * Time.deltaTime, 0f);
    }

    public void ResetBackground()
    {
        bgRenderer.material.mainTextureOffset = Vector2.zero;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class Pathwalkandbackgrounds : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private Renderer bgRenderer;
    // Update is called once per frame
    void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
        //backDrop.uvRect = new Rect(backDrop.uvRect.position + new Vector2(speedX, speedY) * Time.deltaTime, backDrop.uvRect.size);
    }
}

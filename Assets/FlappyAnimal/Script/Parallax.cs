using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float animationSpeed = 1f;
    private MeshRenderer meshRenderer;

    public bool isactive = false;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (isactive)
        {
            meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
        }
    }
    public void enableParallax()
    {
        isactive = true;
        return;
    }
    public void disableParallax()
    {
        isactive = false;
        return;
    }
}

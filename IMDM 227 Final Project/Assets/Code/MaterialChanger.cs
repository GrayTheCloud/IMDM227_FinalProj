using JetBrains.Annotations;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    private Renderer rend;

    void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    public void SetMaterial(Material newMaterial)
    {
        rend.material = newMaterial;
    }
}

using UnityEngine;

public class FocusButtonBehaviour: MonoBehaviour
{
    [SerializeField] private MeshRenderer buttonIcon;
    [SerializeField] private Texture normalTexture;
    [SerializeField] private Texture hoverTexture;

    public Texture NormalTexture { set => normalTexture = value; }
    public Texture HoverTexture { set => hoverTexture = value; }
    private bool HasTriggered { get; set; }

    public void Start()
    {
        if (normalTexture != null)
            buttonIcon.material.mainTexture = normalTexture;
        else
            normalTexture = buttonIcon.material.mainTexture;
    }

    public void OnFocusEnter()
    {
        buttonIcon.material.mainTexture = hoverTexture;
    }

    public void OnFocusExit()
    {
        buttonIcon.material.mainTexture = normalTexture;
    }
}

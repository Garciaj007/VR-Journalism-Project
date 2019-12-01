using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ToggleButtonBehaviour : MonoBehaviour
{
    [System.Serializable]
    public struct State
    {
        public string name;
        public string text;
        public Texture stateNormalTexture;
        public Texture stateHoverTexture;
        public UnityEvent onStateChanged;
    }
    
    [SerializeField] private List<State> states = new List<State>();
    [SerializeField] private TextMeshPro faceText;
    [SerializeField] private TextMeshPro labelText;
    [SerializeField] private MeshRenderer buttonIcon;
    private int currentState = 0;

    public void Start()
    {
        SetState();
    }

    public void OnButtonPressed()
    {
        ++currentState;
        currentState = currentState > states.Count - 1 ? 0 : currentState;
        SetState();
        GetComponent<FocusButtonBehaviour>().OnFocusEnter();
    }

    public void SetState()
    {
        faceText.text = states[currentState].text;
        labelText.text = $"Say \"{states[currentState].text}\"";
        GetComponent<FocusButtonBehaviour>().HoverTexture = states[currentState].stateHoverTexture;
        GetComponent<FocusButtonBehaviour>().NormalTexture = states[currentState].stateNormalTexture;
        states[currentState].onStateChanged?.Invoke();
    }
}

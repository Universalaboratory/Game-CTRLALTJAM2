using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MenuAnimation : MonoBehaviour
{
    public RawImage bg;
    public GameObject txt;
    public GameObject menuPanel;

    private Vector2 initPos;

    [SerializeField] private bool _keyPressed, _transitionOver;

    void Start()
    {
        menuPanel.SetActive(false);
        _keyPressed = false;
        _transitionOver = false;
    }

    void Update()
    {
        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            txt.SetActive(false);
            _keyPressed = true;
        }

        if (_keyPressed)
            MenuTransition();
    }

    private void MenuTransition()
    {
        if (!_transitionOver)
        {
            Debug.LogWarning("Transition Entrou");

            if (bg.uvRect.position.x < 0.499f)
            {
                Debug.LogWarning(" BG Andando");
                bg.uvRect = new Rect(bg.uvRect.position + new Vector2(0.0001f, 0) * Time.deltaTime * 1000, bg.uvRect.size);

            }
            else
            {
                Debug.LogWarning(" BG Chegou");
                menuPanel.SetActive(true);
                _transitionOver = true;
            }
        }
    }
}

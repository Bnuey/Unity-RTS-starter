using UnityEngine;
using UnityEngine.InputSystem;

public class followMouse : MonoBehaviour
{
    [SerializeField] private LayerMask _layer;
    [SerializeField] private GameObject _objectFab;

    Vector3 _screenPos;
    Vector3 _worldPos;

    bool _placing = true;

    private void Update()
    {
        if (_placing) Placing();
        
        if (Input.GetMouseButtonDown(1))
        {
            _placing = false;
            GameObject _object = Instantiate(_objectFab);
            _object.transform.position = transform.position;
            spawnButton.ShowUI?.Invoke();
            Destroy(gameObject);
        }
    }

    private void Placing()
    {
        _screenPos = Mouse.current.position.ReadValue();

        Ray ray = Camera.main.ScreenPointToRay(_screenPos);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100, _layer))
        {
            _worldPos = hitInfo.point;
        }

        _worldPos.y += 0.5f;

        transform.position = _worldPos;
    }
}

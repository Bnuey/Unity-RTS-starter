using System;
using UnityEngine;

public class spawnButton : MonoBehaviour
{
    [SerializeField] private GameObject _placerFab;
    public static Action ShowUI;
    [SerializeField] private GameObject UI;

    public void ButtonClicked()
    {
        Instantiate(_placerFab);
        UI.SetActive(false);
    }

    private void _showUI()
    {
        UI.SetActive(true);
    }
    private void OnEnable()
    {
        ShowUI += _showUI;
    }
    private void OnDisable()
    {
        ShowUI -= _showUI;
    }

}

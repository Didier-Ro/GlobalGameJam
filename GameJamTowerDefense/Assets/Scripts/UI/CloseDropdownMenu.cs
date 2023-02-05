using UnityEngine;

public class CloseDropdownMenu : MonoBehaviour
{
    [SerializeField] private GameObject _background;
    [SerializeField] private Animator _dropdownAnim;
    [SerializeField] private bool _hideDropdown = false;

    private void Update()
    {
        _dropdownAnim.SetBool("Close", _hideDropdown);
    }

    public void IsTrue()
    {
        _hideDropdown = true;
    }

    public void CloseBackgroundMenu()
    {
        _background.SetActive(false);
        _hideDropdown= false;
    }
}

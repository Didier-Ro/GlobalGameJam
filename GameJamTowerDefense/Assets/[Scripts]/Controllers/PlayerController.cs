using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _Lanzero = default;
    [SerializeField] private GameObject _Sebastian = default;
    [SerializeField] private GameObject _heroe = default;
    [SerializeField] private GameObject _heldWeapon = default;
    [SerializeField] private GameObject _soldado = default;
    [SerializeField] private Camera _mainCamera = default;
    [SerializeField] private float _maxRayDistance = 20;
    [SerializeField] private AudioClip _summonSound = default;
    [SerializeField] private GameObject defenderShop= default;
    [SerializeField] private GameObject attackerShop = default;
    [SerializeField] private GameObject attackerButton = default;
    [SerializeField] private GameObject defenderButton = default;
    [SerializeField] private LayerMask _layerMaskGround = default;
    [SerializeField] private UnityEvent<string> OnWeaponPurchased = default;
    [SerializeField] private GameState _gameState = default;
    [SerializeField] private GameObject _minionPrefab;
    [SerializeField] private GameObject _shamanPrefab;

    private void Start()
    {
        StartCoroutine(HeldWeaponRoutine());
    }

    public void CreateWeapon(string weaponType)
    {
        if (_heldWeapon != null)
            return;
        
        switch (weaponType)
        {
            case "Lanzero":
                _heldWeapon = Instantiate(_Lanzero);
                defenderButton.SetActive(false);
                defenderShop.GetComponent<CloseDropdownMenu>().IsTrue();
                BuyingACard(250, false);
                break;
            case "Sebastian":
                _heldWeapon = Instantiate(_Sebastian);
                attackerButton.SetActive(false);
               attackerShop.GetComponent<CloseDropdownMenu>().IsTrue();
                BuyingACard(200, true);
                break;
            case "Heroe":
                _heldWeapon = Instantiate(_heroe);
                attackerButton.SetActive(false);
                attackerShop.GetComponent<CloseDropdownMenu>().IsTrue();
                BuyingACard(850, true);
                break;
            case "Minion":
                _heldWeapon = Instantiate(_minionPrefab);
                defenderButton.SetActive(false);
                defenderShop.GetComponent<CloseDropdownMenu>().IsTrue();
                BuyingACard(175,false);
                break;
            case "Shaman":
                _heldWeapon = Instantiate(_shamanPrefab);
                defenderButton.SetActive(false);
                defenderShop.GetComponent<CloseDropdownMenu>().IsTrue();
                BuyingACard(700,false);
                break;
            case "Soldado":
                _heldWeapon = Instantiate(_soldado);
                attackerButton.SetActive(false);
                attackerShop.GetComponent<CloseDropdownMenu>().IsTrue();
                BuyingACard(150, true);
                break;
            default:
                Debug.LogError($"Weapon type {weaponType} is not valid");
                break;
        }
        
        OnWeaponPurchased?.Invoke(weaponType);
    }

    IEnumerator HeldWeaponRoutine()
    {
        while (_gameState.CurrentGameState == GameState.GameStateEnum.Playing)
        {
            if (_heldWeapon != null)
            {
                Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, _maxRayDistance, _layerMaskGround))
                {
                    _heldWeapon.transform.position = hit.point;
                    if (Input.GetMouseButton(0) && hit.collider.CompareTag("WeaponSlot") && hit.transform.childCount == 0 && _heldWeapon.CompareTag("Azteca"))
                    {
                        _heldWeapon.transform.position = hit.transform.position;
                        _heldWeapon.transform.SetParent(hit.transform);
                        //_heldWeapon.GetComponent<WeaponAttack>().StartWeaponAttack();
                        AudioManager.instance.PlaySFX(_summonSound);
                        _heldWeapon = null;
                    }
                    else if(Input.GetMouseButton(0) && hit.collider.CompareTag("Camino") && hit.transform.childCount == 0 && _heldWeapon.CompareTag("Espanol"))
                    {
                        _heldWeapon.transform.position = hit.transform.position;
                        AudioManager.instance.PlaySFX(_summonSound);
                        _heldWeapon = null;
                    }
                }
            }

            if (Input.GetMouseButton(1))
            {
                Destroy(_heldWeapon);
                if (_heldWeapon.CompareTag("Espanol"))
                {
                    attackerButton.SetActive(false);
                    attackerShop.GetComponent<CloseDropdownMenu>().IsTrue();
                }
                else
                {
                    defenderButton.SetActive(false);
                    defenderShop.GetComponent<CloseDropdownMenu>().IsTrue();
                }
                _heldWeapon = null;
            }

            yield return null;
        }
    }

    public void DestroyObject()
    {

    }
    public void BuyingACard(float cost, bool spain)
    {
        if (RoundManager.RoundInstance._roundLeft > 5 && !spain)
        {
            GameManager.Instance.Player1Gold -= cost;
        }
        else if(RoundManager.RoundInstance._roundLeft >5 && spain)
        {
            GameManager.Instance.Player2Gold -= cost;
        }

        if (RoundManager.RoundInstance._roundLeft < 5 && !spain)
        {
            GameManager.Instance.Player1Gold -= cost;
        }
        else if(RoundManager.RoundInstance._roundLeft < 5 && spain)
        {
            GameManager.Instance.Player2Gold -= cost;
        }
    }
  /*  public void SellACard()
    {
        if (RoundManager.RoundInstance._roundLeft > 5)
        {
            GameManager.Instance.Player1Gold += 200;
        }
        else
        {
            GameManager.Instance.Player1Gold += 200;
        }
    }*/
}
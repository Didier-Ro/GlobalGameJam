using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SacrificeWeapon : MonoBehaviour
{
    [SerializeField] private bool _sacrificeActive = false;
    [SerializeField] private UnityEvent OnSacrificeActive;


    // Update is called once per frame
    void Update()
    {
        if (_sacrificeActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray, out RaycastHit hit))
                {
                    print(hit.collider.gameObject.name);
                    if (hit.collider.CompareTag("Weapon"))
                    {
                        Transform parent = hit.collider.transform.parent;
                        Destroy(parent.gameObject);
                        Sacrifice();
                    }
                }
            }
        }
    }

    public void Sacrifice()
    {
        _sacrificeActive = !_sacrificeActive;
    }
}

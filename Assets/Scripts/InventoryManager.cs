using UnityEngine;

public class InventoryManager : MonoBehaviour {
    private bool _collectedPainkillers;

    public bool CollectedPainKiller
    {
        get { return _collectedPainkillers; }
        set
        {
            _collectedPainkillers = value;

            OnCollectedPainKiller?.Invoke(_collectedPainkillers);
        }
    }

    public delegate void OnVariableChangeDelegate(bool newVal);
    public event OnVariableChangeDelegate OnCollectedPainKiller;

    private bool _collectedGlass;

    public bool CollectedGlass
    {
        get { return _collectedGlass; }
        set
        {
            _collectedGlass = value;

            OnCollectedGlass?.Invoke(_collectedGlass);
        }
    }

    public event OnVariableChangeDelegate OnCollectedGlass;

    private bool _collectedWater;

    public bool CollectedWater
    {
        get { return _collectedWater; }
        set
        {
            _collectedWater = value;

            OnCollectedWater?.Invoke(_collectedWater);
        }
    }

    public event OnVariableChangeDelegate OnCollectedWater;

    public void Raycast()
    {
        var forward = transform.TransformDirection(Vector3.back);

        RaycastHit hit;

        Debug.DrawRay(transform.position, -forward*2, Color.green);

        if (Physics.Raycast(transform.position, -forward, out hit, 2))
        {
            if (hit.collider.name.Equals("painkillers"))
            {
                CollectedPainKiller = true;

                DestroyImmediate(hit.collider.gameObject);
            }
            else if (hit.collider.name.Equals("glass"))
            {
                if (!CollectedPainKiller)
                {
                    return;
                }

                CollectedPainKiller = true;

                DestroyImmediate(hit.collider.gameObject);
            }
            else if (hit.collider.name.Equals("water"))
            {
                if (!CollectedPainKiller || !CollectedGlass)
                {
                    return;
                }

                CollectedPainKiller = true;

                DestroyImmediate(hit.collider.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            Raycast();
        }
    }
}

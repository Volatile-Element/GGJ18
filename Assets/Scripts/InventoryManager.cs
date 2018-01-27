using UnityEngine;
using UnityEngine.SceneManagement;

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
        var camera = Camera.main;

        RaycastHit hit;

        Debug.DrawRay(camera.transform.position, camera.transform.forward * 3, Color.green, 1f);

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 3))
        {
            if (hit.collider.name.Equals("Paracetamol"))
            {
                CollectedPainKiller = true;

                DestroyImmediate(hit.collider.gameObject);

                //TODO: Add actual end game.
                SceneManager.LoadSceneAsync("Game Complete");
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
            else
            {
                var interactable = hit.collider.gameObject.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.Interact();
                }
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

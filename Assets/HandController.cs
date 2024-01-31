using UnityEngine;
using UnityEngine.InputSystem;

public class HandController : MonoBehaviour
{
    [SerializeField] private InputActionProperty triggerAct;
    [SerializeField] private InputActionProperty gripAct;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetFloat("Trigger", triggerAct.action.ReadValue<float>());
        anim.SetFloat("Grip", gripAct.action.ReadValue<float>());
    }
}

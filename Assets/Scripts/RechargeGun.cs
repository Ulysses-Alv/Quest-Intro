using UnityEngine;
using UnityEngine.XR;
using System;
using UnityEngine.XR.Interaction.Toolkit;

public class RechargeGun : MonoBehaviour
{

    private Action _recharge;
    private InputDevice controller;
    private Gun gun => GetComponent<Gun>();
    private XRGrabInteractable interactable => GetComponent<XRGrabInteractable>();

    [SerializeField] private XRRayInteractor left_interactor;

    private void Update()
    {
       _recharge?.Invoke();
    }

    private void Recharge()
    {

        if (gun._bulletsRemaining == 20) return;

        if (controller.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position))
        {
            InputData.instance._HMD.TryGetFeatureValue(CommonUsages.centerEyePosition, out Vector3 HMDposition);

            var heightDistance = Math.Abs(HMDposition.y - position.y);
            if (heightDistance >= 0.5f)
            {
                gun.Recharge();
                RechagerAudioManager.instance.RechargePlay();
            }
        }
    }

    public void Activate()
    {
        controller = interactable.IsSelected(left_interactor) ?
            InputData.instance._leftController :
            InputData.instance._rightController;

        _recharge += Recharge;
    }
    public void Desactivate()
    {
        _recharge -= Recharge;
    }
}
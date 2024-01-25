using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EnableController : MonoBehaviour
{
    private ActionBasedController controller => GetComponent<ActionBasedController>();

    public void DesactivateModel()
    {
        controller.model.gameObject.SetActive(false);
    }
    public void ActivateModel()
    {
        controller.model.gameObject.SetActive(true);
    }
}

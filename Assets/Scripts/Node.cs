using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    public Color cantBuildColor;

    private Vector3 offset = new Vector3(0, 0.5f, 0);
    private Color normalColor;

    [Header("Optional")]
    public GameObject turret;


    private Renderer rend;

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        normalColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.CanBuild)
            return;

        if (turret != null)
        {
            Debug.Log("turret on that node");
            return;
        }

        buildManager.BuildTurretOn(this);

        /*GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + offset, transform.rotation);*/
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        } else
        {
            rend.material.color = cantBuildColor;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = normalColor;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + offset;
    }
}

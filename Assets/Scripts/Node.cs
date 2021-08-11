using UnityEngine;

public class Node : MonoBehaviour
{

    public Color hoverColor;

    private Vector3 offset = new Vector3(0, 0.5f, 0);
    private Color normalColor;
    private GameObject turret;
    private Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        normalColor = rend.material.color;
    }

    void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("turret on that node");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + offset, transform.rotation);
    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = normalColor;
    }
}

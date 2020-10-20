using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StructureSlotTemplate : MonoBehaviour
{
    public GameObject structurePrefab;
    public ConfirmBuildingPanel confirmBuildingPanel;

    private string _materials;
    private string _gold;
    private string _gems;
    private Sprite _icon;
    private GameObject _prefab;
    public Button button;

    private void Start()
    {
        _materials = gameObject.transform.Find("Materials").GetComponent<TextMeshProUGUI>().text;
        _gold = gameObject.transform.Find("Gold").GetComponent<TextMeshProUGUI>().text;
        _gems = gameObject.transform.Find("Gems").GetComponent<TextMeshProUGUI>().text;
        _icon = gameObject.transform.Find("Image").GetComponent<Image>().sprite;

        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(SetData);
    }

    void SetData()
    {
        confirmBuildingPanel.SetData(_icon, _materials, _gold, _gems, structurePrefab);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WallsLvlButton : MonoBehaviour
{
    public ConfirmWallsPanel confirmWallsPanel;
    public Button button;

    private int _materials;
    private int _gold;
    private int _gems;
    private float _wallsDefence;
    private Sprite _icon;

    private Transform _parent;
    private int _index;

    void Start()
    {
        _parent = transform.parent.parent;
        _index = transform.GetSiblingIndex();

        _icon = WallsDatabase.Instance.wallsDatabaseList[transform.GetSiblingIndex()].icon;
        _materials = WallsDatabase.Instance.wallsDatabaseList[transform.GetSiblingIndex()].materialsCost;
        _gold = WallsDatabase.Instance.wallsDatabaseList[transform.GetSiblingIndex()].goldCost;
        _gems = WallsDatabase.Instance.wallsDatabaseList[transform.GetSiblingIndex()].gemsCost;
        _wallsDefence = WallsDatabase.Instance.wallsDatabaseList[transform.GetSiblingIndex()].defenceBonus;

        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(SetData);
    }

    void SetData()
    {
        confirmWallsPanel.SetData(_icon, _materials, _gold, _gems, _wallsDefence, _parent, _index);
    }
}

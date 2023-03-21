using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class ManageElement : MonoBehaviour
{
    protected ManagePage page;

    public int maxCollectCount;
    public int collectCount;
    public long collectAmount;

    // public TextMeshProUGUI collectText;
    public Button button;

    public void Awake() { button.onClick.AddListener(AddResource); }
    public void SetPage(ManagePage page) { this.page = page; }

    public abstract void AddResource();
}

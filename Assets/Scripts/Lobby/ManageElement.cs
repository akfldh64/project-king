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

    public Button button;

    public TextMeshProUGUI collectText;

    public void Awake() { button.onClick.AddListener(AddResource); }
    public void SetPage(ManagePage page) { this.page = page; }

    public virtual void Start() { collectText.SetText($"{maxCollectCount - collectCount}/{maxCollectCount}"); }

    public abstract void AddResource();
}

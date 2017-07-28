using HoloToolkit.Unity.InputModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR.WSA.Input;

public delegate void E_Airtap(string str);

public class WorldSpaceUI : MonoBehaviour {


    #region 字段

    //上一次打开的panel
    private GameObject lasthit;

    //点击后将被点击名字广播出去
    public event E_Airtap e_tap;

    //手势类
    public GestureRecognizer recognizer;


    public TapPanels[] panels = new TapPanels[(int)UItype.panel_count];


    #endregion


    #region 类型

    public enum UItype
    {
        Decorate,   //装饰
        Furniture,  //家具
        Decoration, //物件
        panel_count
    }

    [Serializable]
    public class TapPanels
    {
        public GameObject button;
        public SpriteRenderer maskgrund;
        public SpriteRenderer backgrund;
        public Transform grid;
        public List<Transform> gridbuttons = new List<Transform>();
    }

    #endregion


    #region Unity回调

    void Start()
    {
        //默认开启中间的
        lasthit = panels[1].grid.gameObject;

        // 创建手势识别对象
        recognizer = new GestureRecognizer();
        // 设置手势识别的类型
        recognizer.SetRecognizableGestures(GestureSettings.Tap | GestureSettings.Hold | GestureSettings.DoubleTap);
        // 添加手势识别的事件
        recognizer.TappedEvent += Recognizer_TappedEvent;
        // 开启手势识别
        recognizer.StartCapturingGestures();
    }


    private void OnDestroy()
    {
        recognizer.TappedEvent -= Recognizer_TappedEvent;
    }

    #endregion

    #region 事件

    private void Recognizer_TappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
    {
        string str = GazeManager.Instance.HitObject.name;
        switch (str)
        {
            case "ButtonPlate":
                lasthit.SetActive(false);
                GameObject go = GazeManager.Instance.HitObject.transform.parent.Find("Plane").gameObject;
                go.SetActive(true);
                lasthit = go;
                break;
            default:
                e_tap(str);
                break;
        }
    }
    #endregion




}

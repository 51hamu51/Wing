
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common;

public class Ball_kick : UdonSharpBehaviour
{

    public Env Env;
    private bool SelectY = false;
    private bool SelectX = false;
    private bool Reseted = true;
    private int RotateDelta = 1;
    public Material[] arrowXMaterials = new Material[2];
    public Material[] arrowYMaterials = new Material[2];
    void Start()
    {
        GameObject child = this.gameObject.transform.GetChild(0).gameObject;
        GameObject arrowY = child.transform.GetChild(0).gameObject;
        GameObject arrowX = child.transform.GetChild(1).gameObject;
        //arrowマテリアルを1にする
        arrowY.GetComponent<MeshRenderer>().material = arrowYMaterials[1];
        arrowX.GetComponent<MeshRenderer>().material = arrowXMaterials[1];
    }

    public override void Interact()
    {
        GameObject child = this.gameObject.transform.GetChild(0).gameObject;
        GameObject arrowY = child.transform.GetChild(0).gameObject;
        GameObject arrowX = child.transform.GetChild(1).gameObject;
        if (Reseted)
        {
            Reseted = false;
            SelectY = true;
            RotateDelta = 1;
            arrowY.GetComponent<MeshRenderer>().material = arrowYMaterials[0];
        }
        else if (SelectY)
        {
            SelectY = false;
            SelectX = true;
            RotateDelta = -1;
            arrowY.GetComponent<MeshRenderer>().material = arrowYMaterials[1];
            arrowX.GetComponent<MeshRenderer>().material = arrowXMaterials[0];
        }
        else if (SelectX)
        {
            SelectX = false;
            Reseted = true;
            arrowX.GetComponent<MeshRenderer>().material = arrowXMaterials[1];
            //ここにarrowXとarrowYの向きからける方向に力を加える処理を書く
            Vector3 kickDirection = arrowY.transform.forward;

            //ボールに力を加える
            Rigidbody ballRigidbody = this.gameObject.GetComponent<Rigidbody>();
            ballRigidbody.AddForce(kickDirection * 1000);
            Debug.Log(kickDirection);
        }
    }

    void Update()
    {
        GameObject child = this.gameObject.transform.GetChild(0).gameObject;
        GameObject arrowY = child.transform.GetChild(0).gameObject;
        GameObject arrowX = child.transform.GetChild(1).gameObject;
        // childのY軸を90~-90の範囲を往復させる
        if (SelectY)
        {
            if (child.transform.localEulerAngles.y < 270 && child.transform.localEulerAngles.y > 90)
            {
                RotateDelta *= -1;
            }
            child.transform.Rotate(0, RotateDelta, 0);
        }
        if (SelectX)
        {
            if (child.transform.localEulerAngles.x > 0 && child.transform.localEulerAngles.x < 271)
            {
                RotateDelta *= -1;
            }
            child.transform.Rotate(RotateDelta, 0, 0);
        }
    }
}

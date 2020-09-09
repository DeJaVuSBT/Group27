using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WaterFloat : MonoBehaviour
{
    public float AirDrag = 1;
    public float WaterDrag = 10;
    public bool AffectDirection = true;
    public bool AttachToSurface = false;
    public Transform[] FloatPoints;

    protected Rigidbody Rb;
    protected Waves Waves;

    protected float WaterLine;
    protected Vector3[] WaterLinePoints;
    
    //pysicshelp Vectors
    protected Vector3 smoothVectorRotation;
    protected Vector3 TargetUp;
    protected Vector3 centerOffset;

    public Vector3 Center { get { return transform.position + centerOffset; } }
    void Awake()
    {
        Waves = FindObjectOfType<Waves>();
        Rb = GetComponent<Rigidbody>();
        Rb.useGravity = false;

        //find center
        WaterLinePoints = new Vector3[FloatPoints.Length];
        for (int i = 0; i < FloatPoints.Length; i++) {
            WaterLinePoints[i] = FloatPoints[i].position;
        }
        centerOffset = PhysicsHelper.GetCenter(WaterLinePoints) - transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //default water surface
        var newWaterLine = 0f;
        var pointUnderWater = false;

        //set WaterLinePoints and WaterLine
        for (int i = 0; i < FloatPoints.Length; i++)
        {
            //height
            WaterLinePoints[i] = FloatPoints[i].position;
            WaterLinePoints[i].y = Waves.GetHeight(FloatPoints[i].position);
            newWaterLine += WaterLinePoints[i].y / FloatPoints.Length;
            if (WaterLinePoints[i].y > FloatPoints[i].position.y)
                pointUnderWater = true;
        }

        var waterLineDelta = newWaterLine - WaterLine;
        WaterLine = newWaterLine;

        //compute up vector
        TargetUp = PhysicsHelper.GetNormal(WaterLinePoints);

        //gravity
        var gravity = Physics.gravity;
        Rb.drag = AirDrag;
        if (WaterLine > Center.y)
        {
            Rb.drag = WaterDrag;
            //under water
            if (AttachToSurface)
            {
                //attach to water surface
                Rb.position = new Vector3(Rb.position.x, WaterLine - centerOffset.y, Rb.position.z);
            }
            else
            {
                //go up
                gravity = AffectDirection ? TargetUp * -Physics.gravity.y : -Physics.gravity;
                transform.Translate(Vector3.up * waterLineDelta * 0.9f);
            }
        }
        Rb.AddForce(gravity * Mathf.Clamp(Mathf.Abs(WaterLine - Center.y), 0, 1));

        //rotation
        if (pointUnderWater)
        {
            //attach to water surface
            TargetUp = Vector3.SmoothDamp(transform.up, TargetUp, ref smoothVectorRotation, 0.2f);
            Rb.rotation = Quaternion.FromToRotation(transform.up, TargetUp) * Rb.rotation;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (FloatPoints == null)
        {   return; }

        for (int i = 0; i < FloatPoints.Length; i++) {

            if (FloatPoints[i] == null) { continue; }

            if (Waves != null)
            {
                //draw waterlinepoints
                Gizmos.color = Color.green;
                Gizmos.DrawCube(WaterLinePoints[i], Vector3.one * 0.3f);
            }

            //draw floatpoints
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(FloatPoints[i].position, 0.1f);
        }
        if (Application.isPlaying)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawCube(new Vector3(Center.x, WaterLine, Center.z), Vector3.one * 1f);
        }
    }
}

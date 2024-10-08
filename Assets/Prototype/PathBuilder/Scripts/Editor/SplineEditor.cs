using UnityEngine;
using UnityEditor;

namespace PathBuilder
{
    [CustomEditor(typeof(Spline))]
    public class SplineEditor : Editor
    {
        public void OnSceneGUI()
        {
            Spline spline = target as Spline;

            Handles.color = new Color(1, 0f, 0f, 1);
            for(int i = 0; i < spline.ControlPoints.Length; i++)
            {
                Handles.SphereHandleCap(0, spline.ControlPoints[i], Quaternion.identity, 0.1f, EventType.Repaint);
            }
        }
    }    
}
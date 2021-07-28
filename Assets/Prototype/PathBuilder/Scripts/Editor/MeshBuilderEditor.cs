using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace PathBuilder
{
    [CustomEditor(typeof(MeshBuilder))]
    public class MeshBuilderEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            if(GUILayout.Button("GenerateMesh"))
            {
                MeshBuilder builder = target as MeshBuilder;
                builder.MeshFromSpline(builder.spline, builder.width);
            }
        }
    }
}
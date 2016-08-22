using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(PrefabReplicator))]
public class EditorCreatePrefabs : Editor {
	public override void OnInspectorGUI()
	{
		PrefabReplicator myPrefabReplicator = (PrefabReplicator)target;
		myPrefabReplicator.onePoint = EditorGUILayout.Toggle(myPrefabReplicator.onePoint);
		myPrefabReplicator.initPoint = EditorGUILayout.Vector3Field("Ponto Inicial",myPrefabReplicator.initPoint);
		if(myPrefabReplicator.onePoint==false)
		{
			myPrefabReplicator.finalPoint = EditorGUILayout.Vector3Field("Ponto Final",myPrefabReplicator.finalPoint);
		}
		myPrefabReplicator.dist = EditorGUILayout.FloatField("Distancia entre objetos",myPrefabReplicator.dist);
		myPrefabReplicator.prefabby =  (GameObject)EditorGUILayout.ObjectField(myPrefabReplicator.prefabby, typeof(GameObject),false);

		if(GUILayout.Button("Cria os objetos"))
		{
			myPrefabReplicator.CopyPrefab();
		}

	}

}

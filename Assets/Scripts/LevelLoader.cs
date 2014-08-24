using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelLoader : MonoBehaviour {
	public List<Transform> chunks;
	public float startX = -5.0f;
	private float _currentX = 0.0f;
	public Transform presentLayer;

	void Start() {
		_currentX = startX;
		for(int i = 0; i < 10; i++) {
			float randomY = Random.Range(2.5f, -2.5f);
			int chunkToLoad = Random.Range (0, chunks.Count-1);
			var chunk = Instantiate(chunks[chunkToLoad]) as Transform;
			chunk.position = new Vector3(_currentX, randomY, 0.0f);
			float width = chunk.GetComponent<ChunkScript>().width;
			_currentX += width;
			chunk.parent = presentLayer;
		}
	}
}

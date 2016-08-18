using UnityEngine;
using System.Collections;

public class MCMeshFilter : MonoBehaviour
{
	/*Blobs are a staggered array of floats, where first index is blob, and second is 0=x, 1=y 2=z 3=power
	  Multidim might be slightly faster, but staggered made the code a little cleaner IMO*/
	public float[][] blobs;
	public MCMetablob myBlob;

	// Use this for initialization
	void Start ()
	{
		GetComponent<MeshFilter>().mesh = new Mesh ();
		myBlob = new MCMetablob ();
		myBlob.startEngine (GetComponent<MeshFilter>());

		blobs = new float[5][];
		blobs [0] = new float[]{ .16f, .26f, .16f, .13f };
		blobs [1] = new float[]{ .13f, -.134f, .35f, .12f };
		blobs [2] = new float[]{ -.18f, .125f, -.25f, .16f };
		blobs [3] = new float[]{ -.13f, .23f, .255f, .13f };		
		blobs [4] = new float[]{ -.18f, .125f, .35f, .12f };

		myBlob.Regen ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		blobs [0] [0] = .12f + .12f * (float)Mathf.Sin ((float)Time.time * .50f);
		blobs [0] [2] = .06f + .23f * (float)Mathf.Cos ((float)Time.time * .2f);
		blobs [1] [0] = .12f + .12f * (float)Mathf.Sin ((float)Time.time * .2f);
		blobs [1] [2] = -.23f + .10f * (float)Mathf.Cos ((float)Time.time * 1f);
		blobs [2] [1] = -.03f + .24f * (float)Mathf.Sin ((float)Time.time * .35f);
		blobs [3] [1] = .126f + .10f * (float)Mathf.Cos ((float)Time.time * .1f);
		blobs [4] [0] = .206f + .1f * (float)Mathf.Cos ((float)Time.time * .5f);
		blobs [4] [1] = .056f + .2f * (float)Mathf.Sin ((float)Time.time * .3f);
		blobs [4] [2] = .25f + .08f * (float)Mathf.Cos ((float)Time.time * .2f);

		transform.Rotate (Time.deltaTime * 10f, 0, Time.deltaTime * .6f);

		myBlob.doFrame (blobs);	
	}
}


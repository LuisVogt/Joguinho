using UnityEngine;
using System.Collections;


public class TileScript: MonoBehaviour {
	//O enum transitionState indica de onde o bloco aparece na transição.
	public enum transitionState {DONE,UP,DOWN};
	public enum transitionSpeedType {LINEAR,ACCELERATION};
	//pointStart e pointFinish indicam onde o bloco começa e termina na transição. De modo a simplificar a edição de 
	//cenários, pointFinish é o ponto onde o bloco está no editor.
	Vector3 pointStart;
	Vector3 pointFinish;

	Transform[] child;
	public bool hasChild=false;

	MeshRenderer render;
	Material material;

	Color32 color;

	public float doit;
	int alpha;
	public float dist=1;
	float transitionTime = 0;
	public float porcentagemInicialDeTransparencia = 0;
	public float transitionSpeed = 1.0f;
	public float transitionAcceleration = 0.01f;
	public transitionState transition = transitionState.UP;
	public transitionSpeedType speedType = transitionSpeedType.ACCELERATION;

	public bool Falling = false;

	public bool isFalling()
	{
		return Falling;
	}

	public void startFall()
	{
		Falling = true;
	}
	public transitionState getTransitionState()
		{
			return transition;
		}

	public Vector3 getPointFinish()
	{
		return pointFinish;
	}

	public void setTransparency(float a)
	{
		//Altera a transparência do objeto. 1 é completamente sólido e 0 completamente transparente.
		if(a>1) a = 1;
		else if (a<0) a = 0;
		int temp;
		if(hasChild) temp = transform.childCount;
		else temp = 1;
		for(int i = 0; i < temp;i++){
			if(hasChild) render = transform.GetChild(i).gameObject.GetComponent<MeshRenderer>();
			else render = gameObject.GetComponent<MeshRenderer>();
            if (render != null)
            {
                material = render.material;
                color = material.GetColor("_Color");
                alpha = (int)(a * 255);
                color.a = (byte)alpha;
                material.SetColor("_Color", color);
            }
		}
	}

	public void setPercentageTransparency()
	{
		doit = dist-getDistanceToFinish();
		setTransparency(doit/dist);
	}

	public void finishTransition()
	{
		setTransparency(1);
		material.SetFloat("_Mode",0f);
		transform.position=pointFinish;
		transition=transitionState.DONE;
		Destroy(this);
	}

	public float getTransitionSpeed()
	{
		if(speedType==transitionSpeedType.LINEAR)
			{
				return transitionSpeed;		
			}
		else if (speedType==transitionSpeedType.ACCELERATION)
		{
			transitionSpeed = transitionSpeed + transitionTime * transitionAcceleration;
			return transitionSpeed;
		}
		else 
		{
			return 0;
		}
	}

	public void addTransitionTime(float t)
	{
		transitionTime += t;
	}

	public float getDistanceToFinish()
	{
		return Mathf.Sqrt((transform.position.x - pointFinish.x) * (transform.position.x - pointFinish.x) +
						  (transform.position.y - pointFinish.y) * (transform.position.y - pointFinish.y) + 
						  (transform.position.z - pointFinish.z) * (transform.position.z - pointFinish.z));
	}

	void Start()
	{
		int temp;
		if(transform.childCount>0) {
			temp = transform.childCount;
			hasChild = true;
		}
		else temp=1;
		for(int i = 0; i < temp;i++){
			if(hasChild) render = transform.GetChild(i).gameObject.GetComponent<MeshRenderer>();
			else render = gameObject.GetComponent<MeshRenderer>();
            if (render != null)
            {
                material = render.material;
                color = material.GetColor("_Color");
                material.SetFloat("_Mode", 4f);

                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                material.SetInt("_ZWrite", 0);
                material.DisableKeyword("_ALPHATEST_ON");
                material.EnableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = 3000;
                setTransparency(0);
            }
		}
		if (getTransitionState() != transitionState.DONE)
		{
			pointFinish = transform.position;
			if(getTransitionState() == transitionState.UP)
			{
				pointStart = pointFinish;
				pointStart.y = pointStart.y + 5;
			}

			transform.position = pointStart;
		}

		dist=Mathf.Sqrt((pointStart.x - pointFinish.x) * (pointStart.x - pointFinish.x) + 
						(pointStart.y - pointFinish.y) * (pointStart.y - pointFinish.y) +
						(pointStart.z - pointFinish.z) * (pointStart.z - pointFinish.z));
	}

}

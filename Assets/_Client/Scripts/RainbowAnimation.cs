using UnityEngine;
public class RainbowAnimation : MonoBehaviour
{
    private Vector3 poscng;
    [SerializeField] private float ampl = 1f;
    [SerializeField] private float spd = 1f;
    [SerializeField] private float pos;
    private float elptim;
    private void FixedUpdate()
    {
        poscng.Set(transform.position.x,ampl * Mathf.Sin(spd*elptim)+pos,transform.position.z);
        transform.position = poscng;
        elptim += Time.deltaTime;
    }
}

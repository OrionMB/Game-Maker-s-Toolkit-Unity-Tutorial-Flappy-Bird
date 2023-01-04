using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawn_rate = 8;
    public float current_rate;
    public float move_speed = 5;
    public float current_speed;
    private float timer = 0;
    public float height_offset = 10;
    // Start is called before the first frame update
    void Start()
    {
        current_rate = spawn_rate;
        current_speed = move_speed;
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <current_rate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnPipe();
            timer = 0;
        }
    }

    void SpawnPipe()
    {
        float lowest_point = transform.position.y - height_offset;
        float highest_point = transform.position.y + height_offset;
        GameObject PipeClone = Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowest_point, highest_point), 0), transform.rotation);
        PipeClone.GetComponent<PipeMoveScript>().SetMoveSpeed(current_speed);
    }

    public void UpdatePipeSpawnSpeed(int player_score)
    {
        current_rate = Mathf.Max(spawn_rate / (1 + (float)player_score / 10), 1);
        current_speed = Mathf.Min(move_speed * (1 + (float)player_score / 10), 20);
    }
}

using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Vector3 direction = new Vector3(0, 0, 1f);
    public float speed = 1f;
    public float amountToAddSpeed = 0.02f;

    bool running = true;

    void Update()
    {
        if(!running) return;
        transform.Rotate(direction * (speed * Time.deltaTime * 100f));
    }

    public void AddSpeed(){
        if(speed <= 2.4f)
        speed +=amountToAddSpeed;
    }


    public void EndGame() {
        running = false;
        GameManager.Instance.EndGame();
    }

    public void AddScore() => GameManager.Instance.AddScore();
}


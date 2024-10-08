using UnityEngine;

public class i : MonoBehaviour
{
void Start()
   {
       
   }

   // Update is called once per frame
   void Update()
   {
       Vector2 mousePos = Camera.main.ScreenToWorldPoint( Input.mousePosition);
       transform.position = Vector2.MoveTowards(transform.position, mousePos, 2f * Time.deltaTime);
   }
}

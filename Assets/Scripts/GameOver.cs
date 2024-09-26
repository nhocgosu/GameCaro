
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
   public TextMeshProUGUI textWinner;
 
   public void SetName(string s){
    textWinner.text = s;
   }

}

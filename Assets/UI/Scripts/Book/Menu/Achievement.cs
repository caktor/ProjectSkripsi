using UnityEngine;
using System.Collections;

public class Achievement : MonoBehaviour
{
    public AchievementData[] AchievementData;
    public GameObject AchievementDialog;
    
    

    private void m_generateAchievementData()
    {

        AchievementData = new AchievementData[]
        {
            new AchievementData("Soekarno", "Dr. Ir. H. Soekarno adalah Presiden pertama Republik Indonesia. Ia berperan penting dalam memerdekakan bangsa Indonesia dari penjajahan Belanda. Ia adalah Proklamator Kemerdekaan Indonesia (bersama dengan Mohammad Hatta) yang terjadi pada tanggal 17 Agustus 1945. Soekarno adalah yang pertama kali mencetuskan konsep mengenai Pancasila sebagai dasar negara Indonesia dan ia sendiri yang menamainya."),
            new AchievementData("Hatta", "Dr. Drs. H. Mohammad Hatta adalah pejuang, negarawan, ekonom, dan juga Wakil Presiden Indonesia yang pertama. Ia bersama Soekarno berperan penting untuk memerdekakan bangsa Indonesia dari penjajahan Belanda sekaligus memproklamirkannya pada 17 Agustus 1945. Ia juga pernah menjabat sebagai Perdana Menteri dalam Kabinet Hatta I, Hatta II, dan RIS. Mohammad Hatta juga dikenal sebagai Bapak Koperasi Indonesia."),
            new AchievementData("Sutan Syarir","Sutan Syahrir adalah seorang intelektual, perintis, dan revolusioner kemerdekaan Indonesia.[1] Setelah Indonesia merdeka, ia menjadi politikus dan perdana menteri pertama Indonesia. Ia menjabat sebagai Perdana Menteri Indonesia dari 14 November 1945 hingga 20 Juni 1947."),
            new AchievementData("Tan Malaka","Tan Malaka atau Sutan Ibrahim gelar Datuk Tan Malaka adalah seorang pembela kemerdekaan Indonesia, juga pendiri Partai Murba, dan merupakan salah satu Pahlawan Nasional Indonesia."),
            new AchievementData("Kartini","Raden Adjeng Kartini atau sebenarnya lebih tepat disebut Raden Ayu Kartini adalah seorang tokoh Jawa dan Pahlawan Nasional Indonesia. Kartini dikenal sebagai pelopor kebangkitan perempuan pribumi.")
        };
    }
    // Use this for initialization
    void Start()
    {
        m_generateAchievementData();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

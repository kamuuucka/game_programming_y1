//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TiledMapParser;


//internal class EnemyArray : Enemy
//{
//    public float startX;
//    TiledObject obj;
//    Enemy[] enemies = new Enemy[1];

//    public TiledObject Obj { get; }

//    public EnemyArray(TiledObject obj = null)
//    {
//        startX = obj.X;
//        Console.WriteLine("Enemy startX {0}", startX);
//        EnemiesSpawn();
//        this.obj = obj;
//    }

//    private void EnemiesSpawn()
//    {
//        for (int i = 0; i < enemies.Length; i++)
//        {
//            enemies[i] = new Enemy(obj);
//            if (enemies[i] != null)
//            {
//                enemies[i].SetSpawnX(startX + i * 150f);
//            }
            
//        }
//    }

//    private void EnemiesMovement()
//    {
//        for (int i = 0; i < enemies.Length; i++)
//        {
//            enemies[i].EnemyMovement();
//        }
//    }

//    void Update()
//    {
//        EnemiesMovement();
//    }
//}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace FlappyBirdDemo.Web.Models
{
    public class GameManager
    {
        private readonly int _gravity = 2;

        public event EventHandler MainLoopCompleted;

        public BirdModel Bird { get; private set; }
        public PipeModel Pipe { get; private set; }
        public bool Isrunning { get; private set; } = false;
        public GameManager()
        {
            Bird = new BirdModel();
            Pipe = new PipeModel();
        }

        public async void MainLoop()
        {
            Isrunning = true;
            while (Isrunning)
            {
                Bird.Fall(_gravity);

                Pipe.Move();

                if (Bird.DistanceFromGround <= 0)
                    GameOver();

                MainLoopCompleted?.Invoke(this, EventArgs.Empty);
                await Task.Delay(20);
            }
        }

        public void StartGame()
        {
            if (!Isrunning)
            {
                Bird = new BirdModel();
                MainLoop();
            }
        }
        public void GameOver()
        {
            Isrunning = false;
        }
    }
}

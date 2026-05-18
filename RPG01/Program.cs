namespace RPG01
{
    class StartScene
    {
        public void Start()
        {
            Console.WriteLine("게임 시작 씬입니다.");
        }
        public Player CreatePlayer()
        {
            Console.Write("당신의 이름을 입력 : ");
            string name = Console.ReadLine();

            Player player = new Player();
            player.Name = name;
            Console.Clear();
            Console.WriteLine($"당신의 이름은 {name}이군요.");
            Console.WriteLine("환영합니다! wasd와 방향키로 이동하세요");
            return player;
        }                
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 40);

            StartScene startScene = new StartScene();

            Player player = startScene.CreatePlayer();

            Game game = new Game(player);
            game.Run();
        }
    }
}

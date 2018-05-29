namespace WaterPipes
{
    internal class MainWaterPipes
    {
        public static void Main()
        {
            Pipes waterPipes = new Pipes();
            Pipes.ManualInput(waterPipes);
            waterPipes.Game();
        }
    }
}
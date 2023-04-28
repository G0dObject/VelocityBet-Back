namespace VelocityBet.Game
{
	public class Crush
	{
		public decimal Round()
		{
			Random random = new();
			int startValue = 0;
			int endValue = 10000;
			decimal score = 0.0m;
			bool firstrun = true;


			while (true)
			{
				_ = Task.Delay(20);
				int current = random.Next(startValue, endValue);

				if (firstrun)
				{
					if (current >= 8000)
					{
						return score;
					}
					firstrun = false;
				}
				else
				{
					if (current >= 9980)
					{
						return score;
					}
					startValue++;
					score += 0.01m;
				}
			}
		}
	}
}